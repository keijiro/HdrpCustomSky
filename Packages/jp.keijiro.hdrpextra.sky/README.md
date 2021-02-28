HdrpCustomSky
=============

![screenshot](https://i.imgur.com/t83q8bfl.jpg)

**HdrpCustomSky** is a Unity package that contains custom procedural sky
renderers for HDRP.

System requirements
-------------------

- Unity 2020.2
- HDRP 10.0

How to install the package
--------------------------

This package uses the [scoped registry] feature to import dependent packages.
Please add the following sections to the package manifest file
(`Packages/manifest.json`).

To the `scopedRegistries` section:

```
{
  "name": "Keijiro",
  "url": "https://registry.npmjs.com",
  "scopes": [ "jp.keijiro" ]
}
```

To the `dependencies` section:

```
"jp.keijiro.hdrpextra.sky": "0.0.1"
```

After changes, the manifest file should look like below:

```
{
  "scopedRegistries": [
    {
      "name": "Keijiro",
      "url": "https://registry.npmjs.com",
      "scopes": [ "jp.keijiro" ]
    }
  ],
  "dependencies": {
    "jp.keijiro.hdrpextra.sky": "0.0.1",
...
```

[scoped registry]: https://docs.unity3d.com/Manual/upm-scoped.html

