---
id: 1145
title: Convex Polygon Collider Support in Tiled2Unity
date: 2016-02-07T14:48:58+00:00
author: Seanba
layout: old-post-tiled2unity
permalink: /convex-polygons.html
thesis_description:
  - Tiled2Unity can now export polygons that are strictly convex.
thesis_keywords:
  - Tiled2Unity Unity Tiled Convex Polygons
categories:
  - Uncategorized
---
<img class="alignnone size-full wp-image-1150" src="/assets/wp-content/uploads/2016/02/convex-polygons.png" alt="Convex Polygons" width="640" height="178" srcset="/assets/wp-content/uploads/2016/02/convex-polygons.png 640w, /assets/wp-content/uploads/2016/02/convex-polygons-300x83.png 300w" sizes="(max-width: 640px) 100vw, 640px" />

I've said this before but I think the single best feature in Tiled2Unity is the `PolygonCollider2D` instances that are created from Tiled layers, where the colliders on each tile are merged into one big polygon. Concave edges? Holes? Not a problem.

<div id="attachment_1154" style="width: 535px" class="wp-caption alignnone">
  <img class="size-full wp-image-1154" src="/assets/wp-content/uploads/2016/02/wbml-concave-holes.png" alt="Wonder Boy in Monster World, Concave Colliders" width="525" height="333" srcset="/assets/wp-content/uploads/2016/02/wbml-concave-holes.png 525w, /assets/wp-content/uploads/2016/02/wbml-concave-holes-300x190.png 300w" sizes="(max-width: 525px) 100vw, 525px" />
  
  <p class="wp-caption-text">
    In this scene from Wonder Boy in Monster World, the room colliders are just one big polygon with concave edges and a hole in the middle. It's a great way to represent the collisions but some code may not work with it.
  </p>
</div>

However, some users would like to use the `PolygonCollider2D` instances created by Tiled2Unity and feed them into another Unity script or plugin that performs pathfinding, or real-time lighting, or whatever. The problem is, these other plugins commonly only work with polygons that are convex.

And by the way, if that's a plugin you _bought_ with actual _money_ from the [Unity Asset Store](https://www.assetstore.unity3d.com/) then I think that's weak sauce. Tell those guys to fix their tools!

But I digress ... with the latest Tiled2Unity version you can now set an option to have **only convex polygons exported**.

<img class="alignnone size-full wp-image-1157" src="/assets/wp-content/uploads/2016/02/t2u-convex-checkbox.png" alt="Convex Polygon Option" width="572" height="104" srcset="/assets/wp-content/uploads/2016/02/t2u-convex-checkbox.png 572w, /assets/wp-content/uploads/2016/02/t2u-convex-checkbox-300x55.png 300w" sizes="(max-width: 572px) 100vw, 572px" />

**Note:** Convex polygon output can be also be set through the `-c` or `--convex` options for those of you using the command line.

This will increase the number of `PolygonCollider2D` components in your Tiled prefabs but through the [Hertel-Mehlhorn Algorithm](https://www8.cs.umu.se/kurser/TDBA77/VT06/algorithms/BOOK/BOOK5/NODE194.HTM) I've made that number &#8220;reasonably&#8221; low. For most cases I'd be surprised if there was a noticeable change in performance.

<div id="attachment_1158" style="width: 535px" class="wp-caption alignnone">
  <img class="size-full wp-image-1158" src="/assets/wp-content/uploads/2016/02/wbml-convex.png" alt="Wonder Boy in Monster World, Convex Polygons" width="525" height="333" srcset="/assets/wp-content/uploads/2016/02/wbml-convex.png 525w, /assets/wp-content/uploads/2016/02/wbml-convex-300x190.png 300w" sizes="(max-width: 525px) 100vw, 525px" />
  
  <p class="wp-caption-text">
    With the Convex Polygon Colliders option enabled we have replaced the one &#8220;complex&#8221; polygon with seven convex polygons. This is an increase in prefab complexity but at least we can use it with other scripts that are limited to convex polygons.
  </p>
</div>

## Different Ways to Set Convex Polygon Output

There is some flexibility when it comes to enabling convex polygon exporting:

  * **Tiled2Unity Utility:** Either use the `Convex Polygon Colliders` checkbox in the Win32 utility or use the `-c|--convex` command line option. This will be the preferred setting for exporting polygons for all maps.
  * **Tiled Map:** Add a property named `unity:convex` to your Map Properties in Tiled set to `true` or `false`. This will be the preferred setting for all the layers in your map and will override the setting from the Tiled2Unity utility.
  * **Tiled Layer:** Add the `unity:convex` property to your Layer Properties. This will be the final word on how the polygons in your layer will be exported, overriding the map and utility preferences.

<img class="alignnone size-full wp-image-1160" src="/assets/wp-content/uploads/2016/02/tiled-convex-properties.png" alt="Convex Properties in Tiled Map File" width="555" height="398" srcset="/assets/wp-content/uploads/2016/02/tiled-convex-properties.png 555w, /assets/wp-content/uploads/2016/02/tiled-convex-properties-300x215.png 300w" sizes="(max-width: 555px) 100vw, 555px" />

**Make sure to keep these precedence rules in mind.** If you set `unity:convex` to `true` or `false` in a Tiled layer, for instance, then this will always be obeyed, no matter how you &#8220;prefer&#8221; to export maps in the Tiled2Unity Utility.

As always (and especially with a new feature such as this) you can email me any bugs you come across and I'll find the spare time to address them. Just be aware a full-time game development which slows me down at times. 🙂

_Special thanks go to the [Poly2Tri contributors](https://github.com/zzzzrrr/poly2tri). Their polygon triangulation library came in handy for this feature._