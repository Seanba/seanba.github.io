---
id: 1183
title: Object Type Support Added to Tiled2Unity
date: 2016-04-17T13:07:39+00:00
author: Seanba
layout: old-post-tiled2unity
permalink: /object-type-support.html
thesis_description:
  - Tiled2Unity now allows you to use tiles with different collider types on the same layer.
thesis_keywords:
  - Unity Tiled Map Editor Object Types XML Tile Collision Editor
categories:
  - Uncategorized
---
This is an update I've been waiting awhile for. Recently, [Tiled has been updated](http://forum.mapeditor.org/t/tiled-0-16-0-released/1206) with better support for Object Types.

<div id="attachment_1186" style="width: 463px" class="wp-caption alignnone">
  <img class="size-full wp-image-1186" src="/assets/wp-content/uploads/2016/04/tiled-obj-type-ed.png" alt="Tiled Object Types Editor" width="453" height="325" srcset="/assets/wp-content/uploads/2016/04/tiled-obj-type-ed.png 453w, /assets/wp-content/uploads/2016/04/tiled-obj-type-ed-300x215.png 300w" sizes="(max-width: 453px) 100vw, 453px" />
  
  <p class="wp-caption-text">
    The new Object Types Editor in Tiled allows you create type templates with default properties. With Tiled2Unity 1.0.5.0 these types can automatically be broken up into distinct collision &#8220;layers&#8221;. Default properties can also be passed on to custom importers in Tiled2Unity.
  </p>
</div>

Additionally, the Tile Collision Editor now allows you to set properties on an Object Group or Collision basis.

<div id="attachment_1189" style="width: 595px" class="wp-caption alignnone">
  <img class="size-full wp-image-1189" src="/assets/wp-content/uploads/2016/04/col-ed.gif" alt="Improved Tile Collision Editor" width="585" height="389" />
  
  <p class="wp-caption-text">
    With the new Tile Collision Editor you can assign types to each rectangle, polygon, or polyline collider you add to a tile. You can even have collisions of different types on any tile.
  </p>
</div>

**What doess this mean for Tiled2Unity?** With earlier versions of the utility it could be cumbersome to manage the different collision types you have on your map. For example, say you had a map in Tiled that contained three different collision types ...

<img class="alignnone size-full wp-image-1197" src="/assets/wp-content/uploads/2016/04/cutman-level-part.png" alt="Single Tiled Layer with 3 Different Collider Types" width="512" height="480" srcset="/assets/wp-content/uploads/2016/04/cutman-level-part.png 512w, /assets/wp-content/uploads/2016/04/cutman-level-part-300x281.png 300w" sizes="(max-width: 512px) 100vw, 512px" />

Even though all these tiles could be easily placed on the same Tiled layer you would be forced to put them into separate layers, each with a `unity:layer` custom property on them, in order for them to be exported to Unity as separate `Default`, `Ladders`, and `Spikes` collision objects.

Now, with the latest Tiled and Tiled2Unity, you can simply create new types in the Object Types Editor ...

<div id="attachment_1203" style="width: 408px" class="wp-caption alignnone">
  <img class="size-full wp-image-1203" src="/assets/wp-content/uploads/2016/04/tiled-adding-collision-types.png" alt="Adding Object Types in Tiled" width="398" height="280" srcset="/assets/wp-content/uploads/2016/04/tiled-adding-collision-types.png 398w, /assets/wp-content/uploads/2016/04/tiled-adding-collision-types-300x211.png 300w" sizes="(max-width: 398px) 100vw, 398px" />
  
  <p class="wp-caption-text">
    Here I'm adding new object types for the kinds of colliders I'm interested in (Default, Ladders, and Spikes). The exported TMX map will result in a prefab that breaks out collider objects into these categories.
  </p>
</div>

... and use those types in the Tile Collision Editor ...

<div id="attachment_1204" style="width: 482px" class="wp-caption alignnone">
  <img class="size-full wp-image-1204" src="/assets/wp-content/uploads/2016/04/tiled-using-types-in-collision-editor.png" alt="Setting Type in Collision Editor " width="472" height="412" srcset="/assets/wp-content/uploads/2016/04/tiled-using-types-in-collision-editor.png 472w, /assets/wp-content/uploads/2016/04/tiled-using-types-in-collision-editor-300x262.png 300w" sizes="(max-width: 472px) 100vw, 472px" />
  
  <p class="wp-caption-text">
    Through the Collision Editor we can select the ladder tile and add a collider that uses the Ladders type. Now I can use that tile on any Tile Layer and let the export process do the rest.
  </p>
</div>

... and the collision tiles will be combined into `PolygonCollider2d` objects of the same type for you automatically ...

<div id="attachment_1205" style="width: 599px" class="wp-caption alignnone">
  <img class="size-full wp-image-1205" src="/assets/wp-content/uploads/2016/04/previewer-multiple-collision-layers.png" alt="Preview Using Object Type Colors" width="589" height="557" srcset="/assets/wp-content/uploads/2016/04/previewer-multiple-collision-layers.png 589w, /assets/wp-content/uploads/2016/04/previewer-multiple-collision-layers-300x284.png 300w" sizes="(max-width: 589px) 100vw, 589px" />
  
  <p class="wp-caption-text">
    Here you can see how the tiles are combined with other colliders of the same type. Note you will need to make Tiled2Unity aware of your Object Types XML file in order to use the same color scheme you set in Tiled.
  </p>
</div>

This is done without the need for a custom `unity:layer` property. Note that the `unity:layer` property is still obeyed however if used. This is useful if you have a special Tile Layer that you want to force into a particular collision type.

Note that in order to see the collision type colors in the previewer that you will need to point Tiled2Unity to an Object Types XML file. I suggest you export that file (from the Object Types Editor in Tiled) to the same folder you keep your maps in and keep it updated.

<div id="attachment_1206" style="width: 636px" class="wp-caption alignnone">
  <img class="size-full wp-image-1206" src="/assets/wp-content/uploads/2016/04/t2u-object-types-xml.png" alt="Object Types XML in Tiled2Unity" width="626" height="472" srcset="/assets/wp-content/uploads/2016/04/t2u-object-types-xml.png 626w, /assets/wp-content/uploads/2016/04/t2u-object-types-xml-300x226.png 300w" sizes="(max-width: 626px) 100vw, 626px" />
  
  <p class="wp-caption-text">
    You only need to set the Object Types XML file if you a) Want to see object type colors in the Previewer or b) You have default object property settings you want passed on to custom importers in your Unity project during export.
  </p>
</div>

## Default Object Type Properties Exported Too

Many users won't need to worry about setting the Object Types XML when exporting their Tiled maps. However, if you want default properties to be exported with any Tile Objects to be consumed by a Custom Importer then you will need this setting.

**Note:** For Tiled2UnityLite users (Mac and Linux) you will want to pass the path to your Object Types XML as a command line option. For example:

`Tiled2UnityLite.cs <span style="color: #333399;">-o=/Your/Path/To/objecttypes.xml</span> $TMXPATH $UNITYDIR`

`Tiled2UnityLite.cs <span style="color: #333399;">--object-type-xml=/Your/Path/To/objecttypes.xml</span> $TMXPATH $UNITYDIR`

## Bug Reports Always Welcome

I like to think I do a pretty good job of testing new features added to Tiled2Unity, but, because of reasons, the magnitude of this update is larger than normal. If you experience odd behavior or a fatal crash please send me an email so I can be aware of it.