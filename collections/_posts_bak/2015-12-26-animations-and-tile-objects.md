---
id: 1008
title: Improved Animations and Tile Objects in Tiled2Unity
date: 2015-12-26T21:26:01+00:00
author: Seanba
layout: old-post-tiled2unity
permalink: /animations-and-tile-objects.html
thesis_description:
  - Tiled2Unity has been improved with optimized animations and tile object support.
thesis_keywords:
  - Tiled Map Editor Unity Tiled2Unity animations tile object
categories:
  - Uncategorized
---
Hi there and Happy Holidays. I got some glorious free time this Christmas break to finalize a couple of improvements I've been working on for Tiled2Unity.

As always, you can find the [latest version of Tiled2Unity here]({{ '/tiled2unity/' | relative_url }}).

## Tile Animation Performance

I've long been embarrassed at how I had originally supported tile animations from [Tiled Map Editor](http://www.mapeditor.org/). It was a hack that manipulated vertex data at runtime which was a) slow and b) caused garbage collection spikes as vertex and index buffers were be allocated on the fly. Tiled2Unity now controls animation through enabling and disabling `MeshRenderer` instances. It's cheap and simple.

I've added a new scene to the [Mega Dad example suite]({{ '/megadadadventures/' | relative_url }}.html) that shows off tile animations while revisiting our old NES friend, [Mega Man 2](https://en.wikipedia.org/wiki/Mega_Man_2).

<div id="attachment_1009" style="width: 522px" class="wp-caption alignnone">
  <img class="size-full wp-image-1009" src="/assets/wp-content/uploads/2015/12/flashman-animated.gif" alt="Here I've recreated Flashman's lair from Mega Man 2. The tile animations were made in Tiled and are exported to Unity without any additional work needed. It's meant to be quick and easy." width="512" height="448" />
  
  <p class="wp-caption-text">
    Here I've recreated Flashman's lair from Mega Man 2. The tile animations were made in Tiled and are exported to Unity without any additional work needed. It's meant to be quick and easy.
  </p>
</div>

**Note:** You can find this example (and others) [on GitHub](https://github.com/Seanba/Tiled2Unity-MegaDad) to see how I use Tiled2Unity. All examples have been upgraded to the latest version of Tile2Unity.

## Tile Objects Now Supported

Sometimes you want a single tile placed in your map without the hassle of having it as part of a Tile Layer. These Tile Objects were being exported as a simple transform (no visual tile) with earlier versions of Tiled2Unity. Now they are fully supported.

<div id="attachment_1013" style="width: 219px" class="wp-caption alignnone">
  <img class="size-full wp-image-1013" src="/assets/wp-content/uploads/2015/12/tiled-object-layer.png" alt="Tiled Object Layer" width="209" height="142" />
  
  <p class="wp-caption-text">
    Object Layers are a good way to add extra, level-specific images and tags to your map without managing a whole Tile Layer.
  </p>
</div>

<div class="mceTemp">
</div>

<div id="attachment_1023" style="width: 360px" class="wp-caption alignnone">
  <img class="size-full wp-image-1023" src="/assets/wp-content/uploads/2015/12/tiled-insert-tile-object.png" alt="Tile Object" width="350" height="94" srcset="/assets/wp-content/uploads/2015/12/tiled-insert-tile-object.png 350w, /assets/wp-content/uploads/2015/12/tiled-insert-tile-object-300x81.png 300w" sizes="(max-width: 350px) 100vw, 350px" />
  
  <p class="wp-caption-text">
    Objects are generally exported as colliders by Tiled2Unity but the Tile Object is a special type that lets you place a single tile anywhere in your map. Colliders on that Tile Object are also exported.
  </p>
</div>

## Some Caveats

This was a significant change to Tiled2Unity compared to earlier updates. Here are some things to be aware of:

  * **Unity 4.x support has been removed.** Sorry, but supporting older versions of Unity has become unwieldy. For what it's worth, Sony and Microsoft (and I suspect Nintendo too) are phasing out support for Unity 4.x as well.
  * **Prefab `GameObject` heirarchy has been changed.** In order to better support animations and object rotation and scaling I have changed how Tiled2Unity prefabs are constructed. You may have some scripts that were taking for granted a particular parent-child relationship that will need to be updated. (I recommend using tags to avoid issues like this in the future, not just when using Tiled2Unity, but as a general rule.)

<div class="orange-box" style="margin-bottom: 1em;">
  <strong>Reminder</strong>: Tiled Map Editor has been totally free for years now. Please consider contributing to <a title="Tiled Map Editor on Patreon" href="https://www.patreon.com/bjorn" rel="Tiled Map Editor on Patreon">Thorbjorn Lindeijer’s Patreon</a> for continued <a title="Tiled Map Editor" href="http://www.mapeditor.org/" rel="Tiled Map Editor">Tiled Map Editor</a> support.
</div>