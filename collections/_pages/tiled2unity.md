---
layout: page
title: Get Tiled2Unity
permalink: /tiled2unity.html
redirect_from: "/Tiled2Unity/"
description: Note that Tiled2Unity is now deprecated. Consider using SuperTiled2Unity to import Tiled maps in your Unity projects. It's still free to use.
---
<div class="u-full-width">
  <p class="mytiled2unitywarning">
    Tiled2Unity was created before Unity had support for tiles and tilemaps.
    It is still available for download but is outdated and unsupported. Consider using <a href="/supertiled2unity/">SuperTiled2Unity</a> instead. <strong>Thanks!</strong>
  </p>
</div>

<iframe class="u-full-width" src="https://itch.io/embed/59808" height="167" frameborder="0"></iframe>

Tiled2Unity is a free utility with one goal in mind: **Easy exporting of Tiled Map Editor TMX files into your Unity projects.**
Tiled2Unity takes your Tiled files and creates Unity prefabs from them that are easily placed into your Unity scene.
Complex collision is supported through Unity’s [PolygonCollider2D](https://docs.unity3d.com/ScriptReference/PolygonCollider2D.html) class. (Windows and Mac)

Tiled2UnityLite is a command line version of the Tiled2Unity utility.
It can be used on any platform but was primarily designed to give Linux users a way to use Tiled2Unity on their operating system.

#### Updating Tiled2Unity

When you install a new Tiled2Unity version you will also want to update the Tiled2Unity scripts in your Unity project folder as well.
The easiest way to accomplish this is through the `Import Unity Package to Project` menu item while your project is open in Unity.

![Easily update your Tiled2Unity scripts](assets//wp-content/uploads/2014/06/t2u-package.jpg)

**Note:** Both the Tiled2Unity output window and the Unity console will complain if there is a mismatch.

#### All Source is Freely Available on GitHub

Tiled2Unity is made up of two parts:
1. The Tiled2Unity utility that exports a Tiled file.
2. The Tiled2Unity Unity scripts that imports the *.tiled2unity.xml files and puts the textures, meshes, and prefabs into your Unity project.

Both components are [publicly available on GitHub](https://github.com/Seanba/Tiled2Unity).