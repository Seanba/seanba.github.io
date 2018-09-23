---
id: 696
title: Import Tiled Maps to Unity with Tiled2Unity
date: 2014-05-31T23:48:55+00:00
author: Seanba
layout: old-post-deprecated
permalink: /introtiled2unity.html
thesis_description:
  - Export Tiled TMX files to Unity with the free Tiled2Unity Utility
thesis_keywords:
  - 'Tiled Map Editor Unity TMX files import export Tiled2Unity PolygonCollider2D '
thesis_thumb_width:
  - "66"
thesis_thumb_height:
  - "66"
categories:
  - Uncategorized
---
[<img title="Tiled2Unity" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Tiled2Unity" src="/assets/wp-content/uploads/2014/06/tiled-t2u-unity.jpg" width="640" height="325" />]({{ '/Tiled2Unity/' | relative_url }} "Tiled2Unity: Tiled TMX File Support for Unity")

_(Note: ‘Minimalist’ example artwork is_ [_attributed to Blarget2_](http://opengameart.org/content/minimalist-pixel-tileset "Blarget2 Minimalist Tileset") _via_ [_OpenGameArt.org_](http://opengameart.org/ "Open Game Art"))

If you’ve been working on a 2D tile-based game in the last couple of years then there’s a decent chance you’re familiar with Thorbjørn Lindeijer’s excellent [Tiled Map Editor](http://www.mapeditor.org/ "Tiled Map Editor"). It’s what I used when creating the maps for [Mega Man in Unity]({{ '/mega-man-in-unity/' | relative_url }}.html "Mega Man in Unity") and I’ve now retooled and de-hacked my Tiled-to-Unity exporter (called **Tiled2Unity Utility** because naming things is hard) for general consumption by my fellow game developers  – free of charge under the [MIT License](http://opensource.org/licenses/MIT "MIT License"). I sincerely hope others find it useful.

**You can download the Tiled2Unity Utility from the [Download Page]({{ '/Tiled2Unity/' | relative_url }}).**

**Features:**

  * Builds a Unity prefab out of your TMX map file 
  * Supports all TMX layer formats (XML, CSV, Base64, gzip/zlib compressed) 
  * Multiple layers and tilesets supported 
  * Exports Object Layer as polygons, polylines, rectangles, circles 
  * Tile Layer collisions supported (with slopes, odd-shaped polygons) 
  * Polygon colliders can be concave, have holes, and be composed of separate polygons 
  * Can assign Tag, Sorting Layer, Order in Layer, and (Physics) Layer of exported `GameObject`s through properties in Tiled 
  * Support for customized creation of Unity Prefabs 
  * **Easy to use:** In most cases, you simply export a TMX file into your Unity project and place the automatically generated prefab in your scene – no further edits needed 

**Limitations:**

  * <strike>Orthographic map support only</strike> (Isometric and hexagonal map support in version 0.9.10.0)
  * Ellipse objects are ignored unless they are circular (there is no ellipse collider in Unity) 
  * <strike>Object rotation is currently not supported</strike> (Object rotation added in version 0.9.9.0)
  * Tiled2Unity only runs on Windows out of the box (Prefabs exported into Unity will work on all devices though) (**Note:** See <a title="Tiled2Unity on Non-Windows Platforms" href="{{ '/tiled2unity-is-on-github/' | relative_url }}.html" rel="Tiled2Unity on Non-Windows Platforms">comments section here</a> for support on other platforms)

**Note that I made a purposeful decision not to support isometric maps***. It adds far too much complexity for something that I think is a bit of a hack. I feel orthographic maps should be used at all times and the _illusion_ of top-down or side-scroller or isometric should come from the art, not some weirdo coordinate system. (Your mileage may vary but it’s not like the Nintendo Entertainment System had an isometric mode.)

_*(**Edit to add**: Okay, I relent. Isometric and hexagonal map support has been added as of version 0.9.10.0.)_

## Tiled2Unity Uses Newer Features of the Tiled Map Editor

In order to assign collision data to tiles you will need to use the new **Tile Collision Editor** in Tiled. 

<img title="Tile Collision Editor Menu Item" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Tile Collision Editor Menu Item" src="/assets/wp-content/uploads/2014/05/tiled-view-collision-editor.jpg" width="372" height="192" />

This Tiled feature is currently in beta* so you’ll need to get a version of the program from the daily builds here: [http://files.mapeditor.org/daily/](http://files.mapeditor.org/daily/ "http://files.mapeditor.org/daily/")

For my development and testing I’ve used the May 23rd, 2014 build. (Builds older than April 24th, 2014 will crash if you have collision data in external tilesets.)

_*(**Edit to add**: Not in beta anymore. Just download latest version of Tiled)_

## 

## Getting Started with Tiled2Unity

Before you begin exporting Tiled data into Unity, your project needs to be aware of how it will import the `*.unity2tiled.xml` files that Tiled2Unity spits out. The scripts for this are part of the `Tiled2Unity.unitypackage` file found in the install directory.

There are two ways to import this package into your Unity project:

  1. **From the Tiled2Unity install folder:** Double click on the `Tiled2Unity.unitypackage` file 
  2. **From within Tiled2Unity:** Just select the **“Import Unity Package to Project”** menu item 

<img title="Import Tiled2Unity Unitypackage" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Import Tiled2Unity Unitypackage" src="/assets/wp-content/uploads/2014/05/t2u-package.jpg" width="463" height="190" />

In both cases, Unity will take you through the steps of installing the package into your Unity project. There’s a number of scripts and folders here. You’ll need them all.

<img title="Import all items" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Import all items" src="/assets/wp-content/uploads/2014/05/t2u-import-package.jpg" width="476" height="431" />

Now we’re ready to export some Tiled maps into Unity.

## Using Tiled2Unity Examples

Your Tiled2Unity install contains a couple of TMX file examples. We’re going to open the `minimalist.tmx` file in Unity …

[<img title="Minimalist map" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Minimalist map" src="/assets/wp-content/uploads/2014/05/tiled-minimal_thumb.jpg" width="640" height="443" />](/assets/wp-content/uploads/2014/05/tiled-minimal.jpg)

We don’t _need_ to run Tiled in order to export a TMX file into Unity, but I’ve set up a command in Tiled that will run Tiled2Unity for me.  This allows me to make my map edits in Tiled and then quickly export to Unity by pressing F5.

<img title="Setting Tiled2Unity command in Tiled" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Setting Tiled2Unity command in Tiled" src="/assets/wp-content/uploads/2014/05/tiled2unity-command.jpg" width="629" height="171" />

<pre>"c:\Program Files (x86)\Tiled2Unity\Tiled2Unity.exe" %mapfile c:\MyUnity\Test</pre>

**The command is made up of 3 parts:**

  1. The path to your Tiled2Unity install 
  2. The `%mapfile` macro (this will be the same for all users) 
  3. The path to your Unity project (you can leave this blank and use the Tiled2Unity GUI instead) 

Hitting F5, now Tiled2Unity pops up with our map already loaded and ready to export to our Unity project …

<img title="Running Tiled2Unity from Tiled" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Running Tiled2Unity from Tiled" src="/assets/wp-content/uploads/2014/05/t2u-parse.png" width="637" height="480" />

Now, pressing the **Big Ass Export Button** will export an XML file (in this case, `minimalist.tiled2unity.xml`) to our Unity project where our importer scripts will create the meshes, textures, and materials needed and roll them all up into a prefab named after our TMX file.

<img title="Minimalist map in Unity" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Minimalist map in Unity" src="/assets/wp-content/uploads/2014/05/t2u-imported.jpg" width="584" height="284" />

Now we can place the prefab into our scene hierarchy. (If our map was to be purely decorative then we’d be done.)

<img title="Minimalist prefab placed in scene" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Minimalist prefab placed in scene" src="/assets/wp-content/uploads/2014/05/t2u-placed.jpg" width="610" height="528" />

## Adding Collision Geometry

Chances are most maps we make in Tiled for use in video games will require some collision geometry on them for sprites to interact with. Other solutions I’ve found on the internet or the Unity Asset Store require you to hand-place collision objects by hand in Tiled **which I think is a total PITA**. I’m going to show you how we can easily add _complicated_ collision geometry (with holes, slopes, concave shapes, etc.) to our tile layers that are exported to Unity as `PolygonCollider2D`s.

With Tiled still open on our minimalist map, bring up the **Tiled Collision Editor** an add a Rectangle or Polygon object that fully encloses the solid dark grey tile of our `mini-tile` tileset …

<img title="Add collision to tile" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Add collision to tile" src="/assets/wp-content/uploads/2014/05/tiled-collision-edit-solid.jpg" width="501" height="375" />

Let’s leave the other tiles alone for now and see how we’re doing. Press F5 again to bring up our Tiled2Unity exporter and press the **Preview Exported Map** button to see how the geometry would appear in Unity ...

<img title="First collision preview" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="First collision preview" src="/assets/wp-content/uploads/2014/05/t2u-preview1.jpg" width="601" height="623" />

Here we can see how the geometry of just one tile will be combined into a polygon collider as the tile is repeated throughout the map. Note that, in the resulting collision mesh, there is actually _four_ shapes here &#8212; two of which are rather awkward. Except for not matching the visuals, **that’s actually okay**, the `PolygonCollider2D` in Unity would handle this fine.

Let’s go back to Tiled and add polygons to our sloped tiles …

<img title="Adding sloped collision" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Adding sloped collision" src="/assets/wp-content/uploads/2014/05/tiled-collision-edit-slope.jpg" width="480" height="358" />

(I recommend that **Snap to Grid** and/or **Snap to Fine Grid** is enabled when placing polygons in Tiled)

Previewing again we can see how sloped geometry will be added to the collision mesh …

<img title="Second preview" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Second preview" src="/assets/wp-content/uploads/2014/05/image.png" width="602" height="622" />

Again, this geometry could be exported into our Unity project and the `PolygonCollider2D` created from it **would just work**. 

Going over all our darker tiles and adding polygons/rectangles I get a final preview that I’m pretty happy with …

<img title="Final preview" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Final preview" src="/assets/wp-content/uploads/2014/05/t2u-preview3.jpg" width="605" height="618" />

The best part of this is as we edit the map the collisions assigned to each tile move along with them. You add the geometry to your tiles once, create all the map data you like, and let the exporter take care of the rest.

Here’s the final exported prefab with our `PolygonCollider2D` in Unity …

<img title="Map with collision in Unity" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Map with collision in Unity" src="/assets/wp-content/uploads/2014/05/t2u-placed2.jpg" width="597" height="435" />

And there you go, a 2D tile-based map, authored in Tiled, with collision, in your Unity scene.

_Find any bugs? Is something not working as expected? Got a feature request that makes sense and won’t kill my social life? Feel free to_ [_email me_](mailto:sean@seanba.com)_._

<div class="sba-footnotes">
  <p>
    By the way, the magic behind this polygon construction is courtesy of Angus Johnson’s exceptional (and open source) <a title="Clipper Library" href="http://www.angusj.com/delphi/clipper.php">Clipper</a> library. In my opinion, layer collisions is the most essential feature of Tiled2Unity and Johnson’s Clipper library worked for me <strong>the first time I tried to use it</strong>. C'est Magnifique! *<em>kisses fingertips*</em>
  </p>
</div>