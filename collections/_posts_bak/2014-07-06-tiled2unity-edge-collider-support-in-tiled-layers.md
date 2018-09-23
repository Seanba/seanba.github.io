---
id: 795
title: 'Tiled2Unity: Edge Collider Support in Tiled Layers'
date: 2014-07-06T09:48:18+00:00
author: Seanba
layout: old-post-deprecated
permalink: /tiled2unity-edge-collider-support-in-tiled-layers.html
thesis_description:
  - Tiled2Unity now supports exporting EdgeCollider2D components from polyline objects added through the Tile Collision Editor in Tiled.
thesis_keywords:
  - Tiled Unity Tiled2Unity EdgeCollider2D Polyline Tutorial Export TMX
thesis_thumb_width:
  - "66"
thesis_thumb_height:
  - "66"
categories:
  - Uncategorized
---
<img title="Edge Colliders for One-Way Collision" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Edge Colliders for One-Way Collision" src="/assets/wp-content/uploads/2014/07/Preview_smb3-long.png" width="640" height="146" />

(**Note:** You can play the results of this tutorial <a title="Play the Edge Collider Demo" href="{{ '/unity/tiled2unity/Tiled2UnityEdgeCollider/' | relative_url }}.html" rel="Play the Edge Collider Demo" target="_blank">in the Unity Web Player here</a>. You can also find the Unity package and source Tiled files <a title="Download Edge Collider Example Files" href="{{ '/downloads/Tiled2Unity/Tiled2UnityEdgeCollider/' | relative_url }}.zip" rel="Download Edge Collider Example Files">by downloading here</a>.)

Judging from the emails I’ve been getting, my little <a title="Download Tiled2Unity" href="{{ '/Tiled2Unity/' | relative_url }}" rel="Download Tiled2Unity" target="_blank">Tiled2Unity</a> tool is proving to be useful for developers wanting to bring their <a title="Tiled Map Editor" href="http://www.mapeditor.org/" rel="Tiled Map Editor">Tiled Map Editor</a> levels into their Unity projects.

The best received feature in Tiled2Unity is the ability to <a title="Tiled2Unity Tile Collision Example" href="{{ '/introtiled2unity/' | relative_url }}.html" rel="Tiled2Unity Tile Collision Example" target="_blank">build up collision geometry</a> from the tiles you lay down &#8212; but it only supported creating a `PolygonCollider2D` from rectangle and polygon objects. With the release of Tiled2Unity 0.9.3.0 (<a title="Tiled2Unity Download" href="{{ '/Tiled2Unity/' | relative_url }}" rel="Tiled2Unity Download">download latest Tiled2Unity here</a>),  support has been extended to polylines which are represented as `EdgeCollider2D`s in Unity.

## EdgeCollider2D Example

The most obvious use of this feature is for the type of one-way collision that you find in so many old 2D platforming games. That’s cool but I’ve put together a different kind of example that takes the moving platforms from <a title="Mega Man 2" href="http://en.wikipedia.org/wiki/Mega_Man_2" rel="Mega Man 2">Mega Man 2</a> (yes, again with the Mega Man references) and shows how they could be implemented with help from Tiled2Unity.

<img title="Moving Platform in Mega Man 2" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Moving Platform in Mega Man 2" src="/assets/wp-content/uploads/2014/07/mm2-platforms.png" width="256" height="224" />

These platforms move along a charted path and seems like a great use for the `EdgeCollider2D` class in Unity &#8212; but having to draw out that path by hand would be a total pain. Instead, we’re going to add polylines to the tiles that make up that platform path and have the Tiled2Unity exporter create the `EdgeCollider2D` object for us. This way we could change the visuals of the path and the physical colliders would automatically update to match.

## Adding Polylines To Tiles

We start off with the `platform-map.tmx` file in Tiled …

[<img title="Mega Man2 Map in Tiled" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Mega Man2 Map in Tiled" src="/assets/wp-content/uploads/2014/07/tiled-mm2-platform-map_thumb.jpg" width="633" height="448" />](/assets/wp-content/uploads/2014/07/tiled-mm2-platform-map.jpg)

Just like we’d add polygons and rectangles to tiles in Tiled we can add polylines using the **Tile Collision Editor**.

<img title="Tile Collision Editor - Adding Polylines" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Tile Collision Editor - Adding Polylines" src="/assets/wp-content/uploads/2014/07/tiled-polyline.jpg" width="307" height="368" />

After adding all the polylines to all the “path” tiles we can launch Tiled2Unity and preview the results …

<img title="Edge Collider Preview in Tiled2Unity" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Edge Collider Preview in Tiled2Unity" src="/assets/wp-content/uploads/2014/07/t2upreview-mm2-platform.png" width="293" height="277" />

That path gets built into one continuous EdgeCollider2D component with 44 vertices which is exactly what we wanted. The example comes with a `Platform` sprite which is programmed to traverse that path (see the custom `PlatformCharacterController.cs` script).

<a title="Play the Edge Collider Example in Unity Web Player" href="{{ '/unity/tiled2unity/Tiled2UnityEdgeCollider/' | relative_url }}.html" rel="Play the Edge Collider Example in Unity Web Player"><img title="Tiled2Unity Map Exported to Unity With EdgeCollider2D" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="Tiled2Unity Map Exported to Unity With EdgeCollider2D" src="/assets/wp-content/uploads/2014/07/uni-path-example.png" width="512" height="448" /></a>

And we’re done. Feel free to [download all the tutorial files]({{ '/downloads/Tiled2Unity/Tiled2UnityEdgeCollider/' | relative_url }}.zip "Download Edge Collider Example Files") or <a title="Play the Edge Collider Demo" href="{{ '/unity/tiled2unity/Tiled2UnityEdgeCollider/' | relative_url }}.html" rel="Play the Edge Collider Demo">play the demo</a>. Send questions to me via the comments or [email](mailto:sean@seanba.com). Happy developing.