---
id: 738
title: Additional Tileset Support in Tiled2Unity
date: 2014-06-22T12:29:40+00:00
author: Seanba
layout: old-post-tiled2unity
permalink: /tiled2unity-tilesets.html
thesis_description:
  - Tiled2Unity support for Tilesets that use an alpha color key and for Tilesets that are made up out of a collection of images.
thesis_keywords:
  - Tiled Unity TMX Files Tilesets Alpha Collection Images
thesis_thumb_width:
  - "66"
thesis_thumb_height:
  - "66"
categories:
  - Uncategorized
---
A quick update on some Tileset settings that are now supported in <a title="Tiled2Unity: Tiled TMX file support in Unity" href="{{ '/introtiled2unity/' | relative_url }}.html" target="_blank">Tiled2Unity</a>. (With thanks to readers alerting me to such shortcomings.)

**Note:** You can <a title="Tiled2Unity Download Page" href="{{ '/Tiled2Unity/' | relative_url }}" target="_blank">download the newest version of Tiled2Unity here</a>.

### Alpha Color Key Support

Previously, the shader used by Tiled2Unity on the Unity side was dependent on the alpha channel of textures alone. Old-school games have a history of using a color-key for transparency though so I’ve followed the lead from <a title="Tiled Map Editor" href="http://www.mapeditor.org/" target="_blank">Tiled Map Editor</a> to support this in Tiled2Unity.

<img title="Tranparent Color" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="Tranparent color Tiled supported in Tiled2Unity" src="/assets/wp-content/uploads/2014/06/tileset-alpha-color.png" width="403" height="310" />

Note that in Tiled2Unity you can use both the transparent color and the alpha channel in the same Tileset/texture. You don’t have to go with just one transparency scheme.

### Tilesets Made From Collection of Images

Tiled gives you the ability to create a Tileset from a collection of images. I always work with Tilesets where one image contains many tiles and didn’t even know this feature existed.

<img title="Tiled Tileset from Collection of Images" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="Tiled Tileset from Collection of Images" src="/assets/wp-content/uploads/2014/06/tileset-collection.png" width="403" height="168" />

This is now supported **but a word of warning**: This will increase the number of textures and meshes in your Unity scene. I think it’s worth supporting for prototyping or the odd Tileset but as a rule you’re better served by grouping tiles into larger textures.