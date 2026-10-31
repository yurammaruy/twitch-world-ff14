#!/usr/bin/env python3
"""Gera um arquivo .syso (COFF, AMD64) com icone + manifesto para o linker do Go embutir no .exe."""
import struct
import sys

ico_path, out_path = sys.argv[1], sys.argv[2]

MANIFEST = b"""<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<assembly xmlns="urn:schemas-microsoft-com:asm.v1" manifestVersion="1.0">
  <assemblyIdentity type="win32" name="TwitchWorldFF14.Setup" version="1.0.0.0"/>
  <description>Twitch World FF14 - Instalador</description>
  <trustInfo xmlns="urn:schemas-microsoft-com:asm.v3">
    <security>
      <requestedPrivileges>
        <requestedExecutionLevel level="asInvoker" uiAccess="false"/>
      </requestedPrivileges>
    </security>
  </trustInfo>
  <compatibility xmlns="urn:schemas-microsoft-com:compatibility.v1">
    <application>
      <supportedOS Id="{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}"/>
    </application>
  </compatibility>
</assembly>
"""

# ---------- ler o .ico ----------
ico = open(ico_path, "rb").read()
_, kind, count = struct.unpack("<HHH", ico[:6])
assert kind == 1 and count > 0
images = []
for i in range(count):
    w, h, colors, _, planes, bits, size, off = struct.unpack("<BBBBHHII", ico[6 + 16 * i: 22 + 16 * i])
    images.append((w, h, colors, planes, bits, ico[off:off + size]))

# ---------- recursos: (tipo, id, lingua, bytes) ----------
RT_ICON, RT_GROUP_ICON, RT_MANIFEST = 3, 14, 24
resources = []
for n, (w, h, colors, planes, bits, data) in enumerate(images, start=1):
    resources.append((RT_ICON, n, 0x0409, data))

group = struct.pack("<HHH", 0, 1, len(images))
for n, (w, h, colors, planes, bits, data) in enumerate(images, start=1):
    group += struct.pack("<BBBBHHIH", w, h, colors, 0, planes, bits, len(data), n)
resources.append((RT_GROUP_ICON, 1, 0x0409, group))
resources.append((RT_MANIFEST, 1, 0x0409, MANIFEST))

# agrupa por tipo -> id (ordenados, como exige o formato)
tree = {}
for rtype, rid, lang, data in resources:
    tree.setdefault(rtype, {}).setdefault(rid, []).append((lang, data))
types = sorted(tree)

DIR = 16
ENT = 8
DATAENT = 16

# ---------- calcular posicoes ----------
pos = 0
root_off = pos
pos += DIR + ENT * len(types)

type_dir_off = {}
for t in types:
    type_dir_off[t] = pos
    pos += DIR + ENT * len(tree[t])

lang_dir_off = {}
for t in types:
    for rid in sorted(tree[t]):
        lang_dir_off[(t, rid)] = pos
        pos += DIR + ENT * len(tree[t][rid])

data_ent_off = {}
for t in types:
    for rid in sorted(tree[t]):
        for lang, _ in sorted(tree[t][rid]):
            data_ent_off[(t, rid, lang)] = pos
            pos += DATAENT

blob_off = {}
for t in types:
    for rid in sorted(tree[t]):
        for lang, data in sorted(tree[t][rid]):
            pos = (pos + 3) & ~3
            blob_off[(t, rid, lang)] = pos
            pos += len(data)
total = (pos + 3) & ~3

raw = bytearray(total)
relocs = []


def put_dir(off, n_id):
    struct.pack_into("<IIHHHH", raw, off, 0, 0, 0, 0, 0, n_id)


put_dir(root_off, len(types))
for i, t in enumerate(types):
    struct.pack_into("<II", raw, root_off + DIR + ENT * i, t, 0x80000000 | type_dir_off[t])

for t in types:
    ids = sorted(tree[t])
    put_dir(type_dir_off[t], len(ids))
    for i, rid in enumerate(ids):
        struct.pack_into("<II", raw, type_dir_off[t] + DIR + ENT * i, rid, 0x80000000 | lang_dir_off[(t, rid)])
        langs = sorted(tree[t][rid])
        put_dir(lang_dir_off[(t, rid)], len(langs))
        for j, (lang, data) in enumerate(langs):
            struct.pack_into("<II", raw, lang_dir_off[(t, rid)] + DIR + ENT * j, lang, data_ent_off[(t, rid, lang)])
            de = data_ent_off[(t, rid, lang)]
            # OffsetToData e um RVA: guardamos o deslocamento dentro da secao e pedimos relocacao ADDR32NB
            struct.pack_into("<IIII", raw, de, blob_off[(t, rid, lang)], len(data), 0, 0)
            relocs.append(de)
            raw[blob_off[(t, rid, lang)]: blob_off[(t, rid, lang)] + len(data)] = data

# ---------- arquivo COFF ----------
HEADER = 20
SECTION = 40
raw_ptr = HEADER + SECTION
reloc_ptr = raw_ptr + len(raw)
sym_ptr = reloc_ptr + 10 * len(relocs)

coff = struct.pack("<HHIIIHH", 0x8664, 1, 0, sym_ptr, 1, 0, 0)
coff += struct.pack("<8sIIIIIIHHI", b".rsrc", 0, 0, len(raw), raw_ptr, reloc_ptr, 0, len(relocs), 0, 0xC0000040)
coff += bytes(raw)
for r in relocs:
    coff += struct.pack("<IIH", r, 0, 3)  # IMAGE_REL_AMD64_ADDR32NB, simbolo 0 = secao .rsrc
coff += struct.pack("<8sIhHBB", b".rsrc", 0, 1, 0, 3, 0)  # simbolo da secao (STATIC)
coff += struct.pack("<I", 4)  # tabela de strings vazia

open(out_path, "wb").write(coff)
print(f"ok: {out_path} ({len(coff)} bytes, {len(images)} icones, {len(relocs)} relocacoes)")
