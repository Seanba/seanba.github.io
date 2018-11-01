---
layout: post
title: "Introducing SuperTiled2Unity"
date:   2018-10-31
categories: SuperTiled2Unity Unity Tiled
permalink: /intro-super.html
excerpt_separator: "<!--more-->"
---

<img class="u-full-width" alt="SuperTiled2Unity" src="assets/images/st2u-bar-wide.png"/>

**Tiled2Unity is dead.** Long live [SuperTiled2Unity](supertiled2unity.html). <!--more-->

Since May of 2014, Tiled2Unity has been a popular piece of software, mostly 
due to [Tiled Map Editor](https://www.mapeditor.org/) being an essential 2D authoring tool and because Unity has been slow to support tile-based assets.

However, in the past year I've accumulated **significant fatigue with further Tiled2Unity development** due to these factors:

* The external Tiled2Unity exporter (a C# [Windows Forms](https://en.wikipedia.org/wiki/Windows_Forms) application) was a huge pain to support for both Windows and Mac.
* A small subset of Mac users kept running into crashes I wasn't able to resolve involing managed wrappers of native graphic libraries.
* [Tiled2UnityLite](introducing-tiled2unitylite.html) never took hold as a viable solution for Linux users.
* Tiled files were external to Unity which made debugging difficult. (Users often had maps, tilesets, and textures all over the place which made sharing a pain.)
* Graphical seams was an ongoing drain on support and [the fix for these artifacts](https://tiled2unity.readthedocs.io/en/latest/fixing-seams/) was unsatisfying.
* Unity support for tiles and tilemaps was maturing, thereby deprecating Tiled2Unity (which uses [Wavefront object meshes](https://en.wikipedia.org/wiki/Wavefront_.obj_file)).

For a time I had decided to toss Tiled2Unity to the side but have you tried using Unity as tilemap editor? I think it's a bit of a mess.
Further, I've built up a lot of Tiled data that I didn't want to recreate in Unity's editing environment.

So instead **I've recreated Tiled2Unity from the ground up** taking advantage of new Unity features
such as [Scripted Importers](https://docs.unity3d.com/Manual/ScriptedImporters.html) and [Tilemaps](https://docs.unity3d.com/Manual/Tilemap.html).
The result is SuperTiled2Unity which is now ready for public consumption.

**But beware:** This is an early release. Even Unity considers their new classes as experimental and subject to change.

#### SuperTiled2Unity Improvements

Starting over with a Tiled importer allowed me to resolve these issues:

* **No more external exporter.** Tiled files are now treated as true Unity assets that are automatically imported into prefabs as you make changes in Tiled.
* **Support for all platforms.** Running everything in the Unity Editor puts Windows, Mac OS, and Linux users on an even playing field.
* **Seams fixed once and for all.** Tiles are grouped into a texture atlas during import and padded appropriately so that mathematical imprecision with UV coordinates does not lead to these annoying artifacts.
* **New Unity classes supported.** The Tilemap class is a welcome addition to Unity. No more meshes!

SuperTiled2Unity strives to **compliment all Tiled features** including isometric or hexagonal maps, colliders, flipped tiles, animated tiles, templates, objects, groups, etc..
If a feature is missing [let me know](https://github.com/Seanba/SuperTiled2Unity/issues) and I'll try to support it.

SuperTiled2Unity is [distributed as a single Unity package](SuperTiled2Unity). **And, yes, it is free** but [dontations are always apprecated](donate).

I also encourage everyone to make a contribution towards [further Tiled Map Editor development](https://www.patreon.com/bjorn/overview).
Thorbjørn Lindeijer has put years of effort into Tiled. It's a great program that he easily could have charged real money for. **Please give him your support.**

**Thanks and enjoy!**

<img class="u-full-width" alt="SuperTiled2Unity" src="assets/images/overhead-in-unity.png"/>