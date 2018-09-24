---
id: 858
title: Revisiting Tiled2Unity Scale with Scaled Vertices
date: 2015-03-01T19:33:35+00:00
author: Seanba
layout: old-post-tiled2unity
permalink: /revisit-tiled2unity-scale.html
thesis_title:
  - Tiled2Unity Scaled Vertices
excerpt: Tiled2Unity now supports vertex scaling for tile meshes and collision geometry.
thesis_keywords:
  - Tiled Unity Tiled2Unity scale Pixels Per Unit vertex scaling
categories:
  - Uncategorized
---
<img title="Scaled Vertices" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Scaled Vertices" src="/assets/wp-content/uploads/2015/03/uni-vertex-scaled.png" width="640" height="180" />

A while back <a title="Stupid solution for scaling Tiled2Unity maps" href="{{ '/controlling-tiled2unity-scale/' | relative_url }}.html" rel="Stupid solution for scaling Tiled2Unity maps">I offered a solution</a> for <a title="Tiled2Unity" href="{{ '/tiled2unity/' | relative_url }}" rel="Tiled2Unity">Tiled2Unity</a> users that wanted to partner scaled sprites (using a `Pixels Per Unit` value that was often the 100:1 default) with exported maps that used the (totally more sane) metric of one pixel per one unit in Unity.

**Turns out that solution sucked.** (more below)

Now, starting with **Tiled2Unity 0.9.8.1**, the desired scaling can be baked into the vertices that make up your meshes and collision geometry.

You can set the vertex scale in the Tiled2Unity UI:

<img title="Scaled Vertices in Tiled2Unity UI" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Scaled Vertices in Tiled2Unity UI" src="/assets/wp-content/uploads/2015/03/t2u-vertex-scale-ui.png" width="423" height="198" />

Or you can use a command line argument (`-s=VALUE` or `--scale=VALUE`).

  * **From Tiled:** `Tiled2Unity.exe %mapfile <span style="background-color: #ffff00">-s=0.01</span> c:\My\Unity\Project\Folder` 
  * **From command line:** `Tiled2Unity.exe c:\My\Map\Folder\MyMap.tmx <span style="background-color: #ffff00">--scale=0.01</span>` 

Both examples scale your vertices down to 1/100th of a unit which will be the most common. You can use other values though.

## 

## Problem With the Original Solution

The old way of scaling your exported maps was to instruct Tiled2Unity to hardwire the `Transform` component of the created prefab so that its `scale` matched the `unity:scale` map property in your TMX files. This became be a problem should `GameObject`s transfer in and out of your object hierarchy which is a common enough thing someone may want to do.

Not to beat a dead horse (and I say this as someone with a ton of enthusiasm for Unity) but I view the `Pixels Per Unit` setting in Unity to be a huge hack just to get sprites working with Box2D Physics which is a bad idea anyway for retro 2D games. **I just don’t use it.** However, if that’s the way you roll **I now encourage you to use vertex scaling to get the job done.**

If you decide to go this route keep in mind that the `unity:scale` property is still honored so make sure to rip it out of your TMX files. Otherwise, you’ll end up with prefabs that are scaled twice over.

Happy developing.

**Update:** User Adam offers an alternative way to think of scale in relation to physics …

> For games that do use the physics engine, it seems to me that setting the pixels per unit to the size of your tiles makes sense, in my case 16. That’s because as far as the physics engine is concerned, one unit is one meter. With a tile size of 16, 100 gives you colliders that are too small and 1 gets into some large values that make me worry about floating point errors. 

I can’t argue that. For people relying on the built-in 2D physics provided by Unity this sounds like a reasonable approach.

<div class="orange-box">
  <strong>By the way: </strong>If you enjoy using Tiled then please consider contributing to <a title="Tiled on Patreon" href="https://www.patreon.com/bjorn" rel="Tiled on Patreon">Thorbjorn Lindeijer’s Patreon</a> so that he can work on Tiled fulltime. It’s a great deal for our development community. Even a buck or two per month helps.
</div>