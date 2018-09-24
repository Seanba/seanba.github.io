---
id: 815
title: Tiled Animation Editor Support Added to Tiled2Unity
date: 2014-09-01T11:52:12+00:00
author: Seanba
layout: old-post-tiled2unity
permalink: /tiled-animation-editor-support-added-to-tiled2unity.html
thesis_title:
  - Tiled2Unity Animations
thesis_description:
  - Tiled2Unity now supports tile animations.
thesis_keywords:
  - Tiled Unity Tiled2Unity import export animations Zelda
thesis_thumb_width:
  - "66"
thesis_thumb_height:
  - "66"
categories:
  - Uncategorized
---
**<span style="color: #ff0000;"> Warning: This is an old post!</span>** Animation support in Tiled2Unity is now greatly optimized as of release 1.0.0.0. You can now be more confident that a large number of animations will not sink performance as before.

* * *

&nbsp;

Thanks to prodding and pleading by users I’ve decided to bite the bullet and add support for tile animations that newer builds of <a title="Tiled Map Editor" href="http://www.mapeditor.org/" rel="Tiled Map Editor">Tiled Map Editor</a> allow through its Animation Tile Editor.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="Tile Animation Editor" src="/assets/wp-content/uploads/2014/09/tiled-anim-editor.jpg" alt="Tile Animation Editor" width="346" height="375" border="0" />

In [a previous tutorial]({{ '/megadadadventures/' | relative_url }}.html "The Real Life Adventures of Mega Dad") I demonstrated creating animations by using a combination of layers, tags, and specialized runtime behaviors. This approach is much better.

Like everything I else I try to do with <a title="Tiled2Unity download" href="{{ '/tiled2unity/' | relative_url }}" rel="Tiled2Unity download">Tiled2Unity</a>, the animations from Tiled just work without any extra modifications. To achieve that, I’ve added a `TileAnimator` script that is automatically added to your prefab during the import process if animations are detected.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="Tile Animator instances" src="/assets/wp-content/uploads/2014/09/uni-tile-anims.jpg" alt="Tile Animator instances" width="323" height="476" border="0" />

**Word of warning**: Tiled layers are represented as meshes in Unity. In order to support animations the TileAnimator instances must modify these meshes in real-time. Under some conditions and platforms this may degrade performance. (I doubt it will be any worse then other attempts at animating tiles though.)

## What You’ll Need

In order to get Tiled animations into your Unity projects through Tiled2Unity you will need the following:

  * Tiled2Unity version 0.9.5.3 or later (<a title="Download Tiled2Unity" href="{{ '/tiled2unity/' | relative_url }}" rel="Download Tiled2Unity">download here</a>)
  * A daily build of Tiled Map Editor that support the Tiled Animation Editor. I used the Aug 1st, 2014 build. (<a title="Daily builds of Tiled Map Editor" href="http://files.mapeditor.org/daily/" rel="Daily builds of Tiled Map Editor">download here</a>)

As of this writing the collision and animation editors in Tiled are not in a stable build, hence the need to get a daily build.

## Example Project

Being a big fan of the Zelda series I’ve taken a room out of the Desert Palace from <a title="The Legend of Zelda: A Link to the Past" href="http://en.wikipedia.org/wiki/The_Legend_of_Zelda:_A_Link_to_the_Past" rel="The Legend of Zelda: A Link to the Past">The Legend of Zelda: A Link to the Past</a> as an example. I like how the animated water and lamps bring a bit of life to the room – and no custom scripting or sprite objects are needed.

[<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="Tile Animations" src="/assets/wp-content/uploads/2014/09/tile-anim_thumb.gif" alt="Tile Animations" width="512" height="448" border="0" />](/assets/wp-content/uploads/2014/09/tile-anim.gif)

fixit - downloads below are not supported. Use a github link.

You can [download the example project here]({{ '/downloads/Tiled2Unity/animated-tiles/' | relative_url }}.zip "Tiled2Unity Tile Animation Example") to see it for yourself. It includes both the final Unity project and the source Tiled files (map and textures).

Happy developing.