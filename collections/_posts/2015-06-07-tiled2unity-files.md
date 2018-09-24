---
id: 930
title: Better Control of Tiled2Unity Files in Your Unity Project
date: 2015-06-07T14:25:26+00:00
author: Seanba
layout: old-post-tiled2unity
permalink: /tiled2unity-files.html
thesis_description:
  - Tiled2Unity can now reside anywhere in your Unity project. Also, you can easily instantiate Tiled map prefabs in script by marking them as a resource.
thesis_keywords:
  - Tiled2Unity Tiled Map Editor Unity Instantiate Resources Folder
thesis_thumb_width:
  - "66"
thesis_thumb_height:
  - "66"
categories:
  - Uncategorized
---
Version 0.9.11.0 of Tiled2Unity has just been added to the [Tiled2Unity Download Page]({{ '/tiled2unity/' | relative_url }}). This build contains a couple of new features for power-users.

## You Can Now Put Tiled2Unity Anywhere In Your Unity Project

I had originally hardcoded all the scripts that build a prefab from Tiled2Unity to exist at the `Assets/Tiled2Unity` directory. However, many developers prefer to gather all third-party libraries in a common location and I totally can't blame them for wanting to put Tiled2Unity in a location like `Assets/Scripts/ThirdParty/Tiled2Unity` along with everything else. That is now supported with the latest build of Tiled2Unity.

**One caveat**: I had to change the way the Tiled2Unity exporter is made aware of your Unity project in order to export the right files to the right location. You will now have to explicitly select your Tiled2Unity scripts location in your Unity project instead of just selecting the project root folder. This is done by finding the `Assets/Your/Path/To/Tiled2Unity/Tiled2Unity.export.txt` file in your Unity project.

<div id="attachment_936" style="width: 610px" class="wp-caption alignnone">
  <img class="size-full wp-image-936" src="/assets/wp-content/uploads/2015/06/t2u-export-to.png" alt="Tiled2Unity Exporting" width="600" height="480" srcset="/assets/wp-content/uploads/2015/06/t2u-export-to.png 600w, /assets/wp-content/uploads/2015/06/t2u-export-to-300x240.png 300w" sizes="(max-width: 600px) 100vw, 600px" />
  
  <p class="wp-caption-text">
    The &#8220;Export To ...&#8221; button allows you to choose where to export Tiled maps within your Unity project.
  </p>
</div>

Each install of Tiled2Unity in Unity contains an export marker file that must be selected as the export destination.

<div id="attachment_937" style="width: 635px" class="wp-caption alignnone">
  <a href="/assets/wp-content/uploads/2015/06/t2u-open-file-dialog.png"><img class="size-full wp-image-937" src="/assets/wp-content/uploads/2015/06/t2u-open-file-dialog.png" alt="Tiled2Unity Export Open File Dialog" width="625" height="434" srcset="/assets/wp-content/uploads/2015/06/t2u-open-file-dialog.png 625w, /assets/wp-content/uploads/2015/06/t2u-open-file-dialog-300x208.png 300w" sizes="(max-width: 625px) 100vw, 625px" /></a>
  
  <p class="wp-caption-text">
    You will need to traverse into your Unity project to find the Tiled2Unity/Tiled2Unity.export.txt file. This will instruct the Tiled2Unity exporter where all the textures, materials, meshes, and prefabs will be created for use in your Unity project.
  </p>
</div>

This is just a tiny bit more complicated than earlier builds of Tiled2Unity but I think the trade-off is worth it. Tiled2Unity will remember your last export destination so you won't have to select this every time you export a Tiled map into your project.

## Mark Tiled Maps as Resources For Object Instantiation

Most Tiled2Unity users will simply drop a Tiled2Unity generated prefab into their scene but some developers may want to instantiate a map prefab through script. However, Unity forces developers to place such assets in a `Resources` folder. This meant users would need to export a Tiled map into Unity then move the generated prefab into another folder by hand &#8212; which breaks automation.

With the latest version of Tiled2Unity you can mark a Tiled map with the `unity:resource` property like so ...

<div id="attachment_938" style="width: 315px" class="wp-caption alignnone">
  <img class="size-full wp-image-938" src="/assets/wp-content/uploads/2015/06/tiled-unity-resource.png" alt="Map Property unity:resource" width="305" height="331" srcset="/assets/wp-content/uploads/2015/06/tiled-unity-resource.png 305w, /assets/wp-content/uploads/2015/06/tiled-unity-resource-276x300.png 276w" sizes="(max-width: 305px) 100vw, 305px" />
  
  <p class="wp-caption-text">
    Add a custom property with the name unity:resource (set value of True) to mark the map as a Unity resource. This will allow you to instantiate the map prefab via script.
  </p>
</div>

Normally, Tiled map prefabs are constructed in the `.../Tiled2Unity/Prefabs` folder but with the `unity:resource` property they will reside in `.../Tiled2Unity/Prefabs/Resources` instead. With this you can easily instantiate the prefab in realtime via a Unity script, for example ...

<pre class="brush: csharp; gutter: false;">using UnityEngine;

using System.Collections;



public class MapCreator : MonoBehaviour

{

    void Start()

    {

        UnityEngine.Object prefab = Resources.Load("MyTiledMapPrefab");

        GameObject.Instantiate(prefab);

    }

}

</pre>

Developers employing some kind of procedural generated content scheme should find that useful.

## Added Potential Bonus: Win32 Specific Code Removed

With this latest build I have gone through and removed all dependencies on unmanaged Win32 code (the old export dialog was a big offender). The Tiled2Unity exporter still doesn't officially support any non-Windows platform but people wanting to make Mac or Linux versions run via Mono should have an easier time at it now.

<div class="orange-box" style="margin-bottom: 1em;">
  <strong>Reminder</strong>: Tiled Map Editor has been totally free for years now. Please consider contributing to <a title="Tiled Map Editor on Patreon" href="https://www.patreon.com/bjorn" rel="Tiled Map Editor on Patreon">Thorbjorn Lindeijer’s Patreon</a> for continued <a title="Tiled Map Editor" href="http://www.mapeditor.org/" rel="Tiled Map Editor">Tiled Map Editor</a> support.
</div>