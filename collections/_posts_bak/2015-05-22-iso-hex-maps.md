---
id: 922
title: Isometric and Hexagonal Map Support in Tiled2Unity
date: 2015-05-22T00:21:22+00:00
author: Seanba
layout: old-post-deprecated
permalink: /iso-hex-maps.html
thesis_description:
  - Tiled2Unity now supports exporting Isometric and Hexagonal maps into your Unity projects.
thesis_keywords:
  - Tiled Map Editor Unity Hexagonal Tiled2Unity Patreon Import Export
thesis_thumb_width:
  - "66"
thesis_thumb_height:
  - "66"
categories:
  - Uncategorized
---
<img title="Isometric and Hexagonal Maps in Tiled2Unity" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Isometric and Hexagonal Maps in Tiled2Unity" src="/assets/wp-content/uploads/2015/05/unity-iso-map.png" width="640" height="240" />

_(Note: Isometric artwork is_ <a title="Outside Tileset (Isometric)" href="http://opengameart.org/content/isometric-64x64-outside-tileset" rel="Outside Tileset (Isometric)"><em>attributed to Yar</em></a> _via_ <a title="OpenGameArt.Org" href="http://opengameart.org/" rel="OpenGameArt.Org"><em>OpenGameArt.org</em></a>_)_ 

Since **Tiled2Unity’s** release I’ve held firm on not supporting isometric maps due to two reasons:

  1. The game developers of days gone were limited to square tilesets and depended on artwork to give the illusion of their view whether it be top-down, side-view, 2.5D, whatever. Isometric (and hexagonal) were no different – you just bake the effect into the pixels. 
  2. It’s a pain in the ass to implement. 

However, my inbox tells me my fellow developers would really like to export their isometric maps to <a title="Unity" href="https://unity3d.com/" rel="Unity">Unity</a> with the same relative ease that their orthographic brothers and sisters enjoy. Also, I couldn’t go on pretending Tiled2Unity was the perfect companion app to <a title="Tiled Map Editor" href="http://www.mapeditor.org/" rel="Tiled Map Editor">Tiled</a> for Unity developers when a major feature was not being supported.

## Tiled2Unity: Isometric and Hexagonal Maps

If you download the <a title="Tiled2Unity Download Page" href="{{ '/Tiled2Unity/' | relative_url }}" rel="Tiled2Unity Download Page">latest version of Tiled2Unity</a> you will find support for the following map types (in addition to orthographic):

  * Isometric 
  * Isometric Staggered 
  * Hexagonal (including <a title="Hexagonal Coordinate Systems" href="http://www.redblobgames.com/grids/hexagons/#coordinates" rel="Hexagonal Coordinate Systems">all 4 variations</a> of the coordinate system) 

That’s every map type that Tiled is capable of creating right now, and, just like with orthographic maps, you can export collision objects into your Unity projects.

[<img title="Isometric Preview (with collisions)" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Isometric Preview (with collisions)" src="/assets/wp-content/uploads/2015/05/t2u-iso-preview_thumb.png" width="285" height="194" />](/assets/wp-content/uploads/2015/05/t2u-iso-preview.png)

<img title="Hexagonal Preview (with collisions)" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Hexagonal Preview (with collisions)" src="/assets/wp-content/uploads/2015/05/t2u-hex-preview.png" width="285" height="274" />

_(Note: Hexagonal artwork is attributed to_ <a title="Steffen from TilemapKit" href="http://tilemapkit.com/author/steffen/" rel="Steffen from TilemapKit"><em>Steffen</em></a> _via_ <a title="TilemapKit" href="http://tilemapkit.com/2015/05/create-hexagonal-tilemaps-in-tiled/" rel="TilemapKit"><em>TilemapKit</em></a>_)_

## Object Colliders in Isometric Mode

The isometric map mode in Tiled skews your collision objects so that rectangles becomes parallelograms and circles become ellipses. This complicates things a bit for us in Unity.

[<img title="Object Shapes in Isometric Mode" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Object Shapes in Isometric Mode" src="/assets/wp-content/uploads/2015/05/tiled-object-shapes-iso_thumb.png" width="437" height="233" />](/assets/wp-content/uploads/2015/05/tiled-object-shapes-iso.png)

For all other map types (including isometric staggered) the rectangle object will be exported as a `BoxCollider2D` and the circle a `CircleCollider2D`. Easy.

For the isometric map type the rectangle will be exported as a `PolygonCollider2D` and will keep the shape as displayed in the image above. **The circle, however, will be lost**. Note that ellipses with uneven width and height have never been supported in Tiled2Unity due to the lack of an `EllipseCollider2D` in Unity. Now that the circle in the example above is _really_ an ellipse it falls into that category. Sorry, no cheap circle collisions here. If you really need a circle collider I suggest you go with an isometric staggered map instead.

## Beware of Visual Seams

Depending on how your isometric and hexagonal tilesets are authored you may see a lot of visual seams in your Unity project with some camera settings and shaders.

Here’s an example of an 8&#215;8 isometric tile …

<img title="Single 8x8 Isometric Tile" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Single 8x8 Isometric Tile" src="/assets/wp-content/uploads/2015/05/iso-single-tile.png" width="128" height="128" />

… and how you’d expect tiles like this to be rendered together …

<img title="Isometric Tiles Grouped Together (expected)" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Isometric Tiles Grouped Together (expected)" src="/assets/wp-content/uploads/2015/05/iso-group-expected.png" width="270" height="254" />

However, due to mathematical imprecision with the texture sampler you may end up with something that looks like this under certain conditions …

<img title="Isometric Tiles with Seams" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Isometric Tiles with Seams" src="/assets/wp-content/uploads/2015/05/iso-group-seams.png" width="274" height="258" />

The best way to avoid this is to add extra pixels that bleed outside the isometric shape …

<img title="Bleed Out Tiles to Avoid Seams" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Bleed Out Tiles to Avoid Seams" src="/assets/wp-content/uploads/2015/05/iso-single-tile-bleed.png" width="160" height="160" />

Generally, those extra pixels will be overlapped by the “proper” pixels of a neighboring tile but in the case where the texture sampling goes a bit out of bounds you’ll be covered.

<img title="Isometric Tiles With No Seams" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Isometric Tiles With No Seams" src="/assets/wp-content/uploads/2015/05/iso-group-no-seams.png" width="274" height="258" />

**Important Note:** Do no increase the size of your tiles in Tiled to make up for those extra pixels. That’s what the `margin` setting is for in your tileset**.** Even though the “bleeding” tiles above may now be 10&#215;10, they are really 8&#215;8 tiles with 1 pixel margins.

## What if You’ve Found a Bug?

I generally don’t work with isometric or hexagonal maps so at this time I can’t say this tech is too battle tested. If you’ve found an issue you can always leave a comment below or [email me](mailto:sean@seanba.com). I’m a <a title="About me" href="{{ '/about/' | relative_url }}" rel="About me">fulltime game developer</a> by day and a hobbyist programmer by night so keep in mind I can’t always reply right away.

## Please Support Tiled on Patreon

I talk about this a lot because I know from Tiled2Unity alone that there is _a lot_ of enthusiasm out there for Thorbjørn Lindeijer’s work with <a title="Tiled Map Editor" href="http://www.mapeditor.org/" rel="Tiled Map Editor">Tiled Map Editor</a>. It is difficult to support the game development community as well as he has with a career and a family so please consider pledging to <a title="Support Bjorn on Patreon" href="https://www.patreon.com/bjorn?ty=h" rel="Support Bjorn on Patreon">Bjørn’s Patreon</a> in hopes of **making Tiled even better** his new fulltime job.

Even a couple of dollars each month adds up quickly so please join me in helping Bjørn reach his goal.

<a title="Support Tiled on Patreon" href="https://www.patreon.com/bjorn?ty=h" rel="Support Tiled on Patreon"><img title="Tiled on Patreon" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Tiled on Patreon" src="/assets/wp-content/uploads/2015/05/tiled-on-patreon.png" width="640" height="133" /></a>