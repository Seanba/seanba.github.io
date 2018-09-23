---
id: 883
title: Previewer Improvements with Tiled2Unity
date: 2015-03-09T22:15:41+00:00
author: Seanba
layout: old-post-deprecated
permalink: /previewer-improvements-tiled2unity.html
thesis_description:
  - The previewer in Tiled2Unity is improved with the addition of Previewer Options.
thesis_keywords:
  - Tiled Unity Tiled2Unity Previewer Options Collision Color AdvanceWars
categories:
  - Uncategorized
---
<div class="orange-box" style="margin-bottom:1em;">
  <strong>Note</strong>: My <strong>Tiled2Unity</strong> utility is available for download <a title="Download Tiled2Unity" href="{{ '/tiled2unity/' | relative_url }}" rel="Download Tiled2Unity">on this page</a>. Also, please consider contributing to <a title="Tiled Map Editor on Patreon" href="https://www.patreon.com/bjorn" rel="Tiled Map Editor on Patreon">Thorbjorn Lindeijer’s Patreon</a> for continued <a title="Tiled Map Editor" href="http://www.mapeditor.org/" rel="Tiled Map Editor">Tiled Map Editor</a> support.
</div>

I’ve been working on an upcoming Tiled2Unity tutorial to help people that are trying to get information for a specific tile at a specific location at runtime.

For instance, say your working on a game like Advance Wars where the game logic has a dependency on the type of tiles that make up a level (grass, trees, mountains, etc.)

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Advance Wars 2 (Copyright Nintendo)" src="/assets/wp-content/uploads/2015/03/Spann_Island_AW2.png" alt="Advance Wars 2 (Copyright Nintendo)" width="240" height="160" border="0" />

Achieving this with Tiled2Unity is done through having all the different tile types (with collisions) on separate Tile Layers and using a raycast against their generated `PolygonCollider2D` objects. This gives you the ability  to know which “type” of tile you are “using”. Further, I use <a title="Automapping in Tiled" href="https://github.com/bjorn/tiled/wiki/Automapping" rel="Automapping in Tiled">Tiled’s Automapping capabilities</a> so that I only manage one Tile Layer and let the Automapper take care of the rest. (More on that in the upcoming tutorial.)

The idea isn’t that difficult but the previewer in Tiled2Unity was a huge disappointment for a map with multiple collider layers. Here is a screenshot of it in action …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Can't see collisions" src="/assets/wp-content/uploads/2015/03/preview-old.png" alt="Can't see collisions" width="557" height="397" border="0" />

What a mess. There’s six different kinds of polygons in that picture (plus a bunch of rectangles to indicate sprite location) but it’s impossible to tell where they are.

So, the latest versions of Tiled2Unity has previewer options …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Right-click to bring up Previewer Options" src="/assets/wp-content/uploads/2015/03/t2u-previewer.png" alt="Right-click to bring up Previewer Options" width="370" height="316" border="0" />

… that allow you to select which layers are being shown in the previewer. They also allow you to choose a color for the collision polygons on a per-layer basis:

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Previewer Options (Per Layer)" src="/assets/wp-content/uploads/2015/03/t2u-previewer-options-menu.png" alt="Previewer Options (Per Layer)" width="341" height="355" border="0" />

(BTW, the color settings are saved to file so that you don’t have to reset them every time you use the previewer. Other maps that use similar layer names will inherit these colors while previewing.)

Now we can get a much better sense of how polygon colliders are going to be created in Unity.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Much better view of collisions" src="/assets/wp-content/uploads/2015/03/preview-new-full.png" alt="Much better view of collisions" width="557" height="397" border="0" />

We can take this one step further. The collision layers in this example (CollisionWood, CollisionMountain, etc.) make use of the `unity:collisionOnly` custom property. This tells Tiled2Unity that we only want collision polygons for these layers and ignores the mesh that would normally go with them.

Given this we can preview only these layers and get an even better sense of the colliders that will be created by Tiled2Unity. Notice how the blue water polygon stands out. (And yes, that’s _one polygon_ in Unity.)

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Viewing only collisions" src="/assets/wp-content/uploads/2015/03/preview-new-select.png" alt="Viewing only collisions" width="557" height="397" border="0" />

What I like most about Tiled2Unity (and why I made it available to the public as a side-effect of my <a title="Mega Man in Unity" href="{{ '/mega-man-in-unity/' | relative_url }}.html" rel="Mega Man in Unity">Mega Man game</a>) is that all of this information for the map is going to be represented by just a few polygons – and not some O(N<sup>2</sup>) number of per-tile objects.

And now, it’s easier to see that in the previewer. Happy developing.