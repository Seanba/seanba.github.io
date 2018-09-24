---
id: 1058
title: Introducing Tiled2UnityLite with Support for OSX/Linux
date: 2015-12-31T19:15:17+00:00
author: Seanba
layout: old-post-tiled2unity
permalink: /introducing-tiled2unitylite.html
thesis_description:
  - Tiled2Unity is now available for use on OSX and Linux platforms through Tiled2UnityLite, the command line utility version of this popular 2D game development tool.
thesis_keywords:
  - Tiled Unity Tiled2Unity Tiled2UnityLite Max OSX Linux scripting
categories:
  - Uncategorized
---
**Update:** Tiled2UnityMac is now available (as of version 1.0.7.0) for Mac OS X with a full-fledged GUI.

<img class="alignnone size-full wp-image-1071" src="/assets/wp-content/uploads/2015/12/tiled2unitylite.cs_.png" alt="Tiled2UnityLite" width="616" height="372" srcset="/assets/wp-content/uploads/2015/12/tiled2unitylite.cs_.png 616w, /assets/wp-content/uploads/2015/12/tiled2unitylite.cs_-300x181.png 300w" sizes="(max-width: 616px) 100vw, 616px" />

**Happy New Year's Eve!**

Over the holidays I decided I was finally going to do _something_ about helping our friends on OSX and Linux systems get Tiled2Unity working within their development environments. I'm now happy to say that a command-line version of Tiled2Unity (named Tiled2UnityLite) is now available that gives any platform running [Mono](http://www.mono-project.com/docs/getting-started/install/mac/) and [CS-Script](http://www.csscript.net/) the capability of exporting Tiled maps into Unity.

**Don't let the name fool you: ** The &#8216;Lite' part simply means there is no GUI like in Tiled2Unity proper. You still get the exporting options we've been enjoying on Windows for some time now. The only thing you're _really_ missing is the previewer in the Tiled2Unity GUI but I suspect that feature isn't used all that much anyhow.

<div id="attachment_1103" style="width: 592px" class="wp-caption alignnone">
  <a href="/assets/wp-content/uploads/2015/12/t2u-previwer-mother-brain.png" rel="attachment wp-att-1103"><img class="size-full wp-image-1103" src="/assets/wp-content/uploads/2015/12/t2u-previwer-mother-brain.png" alt="Tiled2Unity Previewer" width="582" height="353" srcset="/assets/wp-content/uploads/2015/12/t2u-previwer-mother-brain.png 582w, /assets/wp-content/uploads/2015/12/t2u-previwer-mother-brain-300x182.png 300w" sizes="(max-width: 582px) 100vw, 582px" /></a>
  
  <p class="wp-caption-text">
    The Tiled2Unity Previewer takes great screenshots but once your map is set up for rapid edit-and-export it becomes less useful.
  </p>
</div>

A benefit of Tiled2UnityLite is that it is distributed _as a single C# file._ This makes it useful for making Tiled2UnityLite part of an automated build pipeline as well.

Below I explain how I got Tiled2UnityLite to run from Tiled Map Editor on a MacBook running Yosemite. Eventually, the goal is to have it set up where you **press F5 to automatically export TMX files to Unity**. This can be a (one-time) pain for some depending on how comfortable they are with environment variables and shell scripting. (I'm by no means an OSX power user so if someone comes up with better instructions I'll be happy to post them.)

**The main gist is this**:

  * Install Mono (Windows users don't need to do this, nor invoke `mono` on the command line)
  * Install CS-Script
  * Download Tiled2UnityLite.cs
  * Run a command from the terminal that runs `Tiled2UnityLite.cs` through CS-Script

The command should resolve to something like this:

<pre class="brush: plain; title: ; notranslate" title="">mono cscs.exe Tiled2UnityLite.cs YourMap.tmx YourProject/Assets/Tiled2Unity

</pre>

## Installing Mono

Just go to [the Mono website](http://www.mono-project.com/docs/getting-started/install/mac/) and follow their instructions. Piece of cake.

## Installing CS-Script

CS-Script is a clever utility that allows you to use C# _as a scripting language_. Time was I used Ruby for all my scripting needs but I find myself writing C# and executing it at runtime through CS-Script more and more now. It's a great tool &#8212; and it's the key to having Tiled2UnityLite work on systems I hadn't planned on supporting.

However, I did have some difficultly getting CS-Script running on OSX. This is likely due to my weak sauce Mac-fu but perhaps my instructions will be of help to others anyhow (El Capitan users and others wanting to install CS-Script to a directory of their choosing **see import update below**):

  * Download CS-Script [from their website](http://www.csscript.net/CurrentRelease.html)
  * Unzip, rename folder from `cs-script` to `CS-Script` and copy folder to `usr/share/` 
      * The CS-Script executable should be as this location: `/usr/share/CS-Script/cscs.exe`
  * Give `usr/share/CS-Script` execute and write permissions 
      * In the terminal: `sudo chmod 777 /usr/share/CS-Script`

I also needed to update my `.bash_profile` file so that CS-Script was in my PATH:

<pre class="brush: plain; title: ; notranslate" title="">export CSSCRIPT_DIR=/usr/share/CS-Script
export PATH=$PATH:$CSSCRIPT_DIR</pre>

At this point you should be able to run CS-Script from the terminal:
<pre class="brush: plain; title: ; notranslate" title="">mono $CSSCRIPT_DIR/cscs.exe -v

C# Script execution engine. Version 3.9.20.0.
Copyright (C) 2004-2014 Oleg Shilo. www.csscript.net

   CLR:            4.0.30319.17020
   System:         Unix 14.0.0.0
   Architecture:   x86
   Home dir:       /usr/share/CS-Script
</pre>

With that achieved we're ready to run C# files as a script.

<span style="color: #ff0000;"><strong>Update for El Capitan users:</strong></span> The directions above won't exactly work because El Capitan does not allow write access to `/usr/share`. Try these modified steps as a work-around:

  * Install CS-Script to this location instead: `/usr/local/CS-Script`
  * Add this to your .bash_profile: `export css_nuget=/usr/local/CS-Script/nuget`
  * (Actually, these directions should allow you to install CS-Script anywhere.)

## Download and Run Tiled2UnityLite

You can download Tiled2UnityLite from the [Tiled2Unity download page]({{ '/tiled2unity/' | relative_url }}) as a separate zip. This zip contains two files:

  * `Tiled2Unity.unityproject` - Include this package in your Unity project.
  * `Tiled2UnityLite.cs` - The C# file that contains all the Tiled2Unity source, all 10,000+ lines of it, with all the Windows-specific stuff excised out.

Go to the directory you've unzipped Tiled2UnityLite.cs to and run the help command on our script.

<pre class="brush: plain; title: ; notranslate" title="">mono $CSSCRIPT_DIR/cscs.exe Tiled2UnityLite.cs --help

Tiled2UnityLite Utility, Version: 1.0.1.0
Usage: Tiled2UnityLite [OPTIONS]+ TMXPATH [UNITYDIR]
Example: Tiled2UnityLite -s=0.01 MyTiledMap.tmx ../../MyUnityProject/Assets/Tiled2Unity

Options:
  -s, --scale=VALUE          Scale the output vertices by a value.
                               A value of 0.01 is popular for many Unity 
                               projects that use 'Pixels Per Unit' of 100 for 
                               sprites.
                               Default is 1 (no scaling).
  -t, --texel-bias=VALUE     Bias for texel sampling.
                               Texels are offset by 1 / value.
                               Default value is 8192.
                                A value of 0 means no bias.
  -v, --verbose              Print verbose messages.
  -h, --help                 Display this help message.

Prefab object properties (set in TMX file for each layer/object)
  unity:sortingLayerName
  unity:sortingOrder
  unity:layer
  unity:tag
  unity:scale
  unity:isTrigger
  unity:ignore (value = [false|true|collision|visual])
  unity:resource
  (Other properties are exported for custom scripting in your Unity project)
</pre>

Once your environment is configured to run Tiled2UnityLite like this then you are ready to export Tiled maps directly from Tiled Map Editor into your Unity project using the Execute Command GUI.

<img class="alignnone size-full wp-image-1089" src="/assets/wp-content/uploads/2015/12/tiled-mac-commands.png" alt="Tiled Command Editor" width="620" height="193" srcset="/assets/wp-content/uploads/2015/12/tiled-mac-commands.png 620w, /assets/wp-content/uploads/2015/12/tiled-mac-commands-300x93.png 300w" sizes="(max-width: 620px) 100vw, 620px" />

<pre class="brush: plain; title: ; notranslate" title="">/bin/sh /MyPath/tiled2unitylite.sh %mapfile /MyProject/Assets/Tiled2Unity
</pre>

You'll notice I decided to run a shell script from Tiled when exporting to Unity. I'll explain that a bit below but for now the command I use in Tiled is broken up into a number of parts:

  1. `/bin/sh` This tells the operating system we'll be running a shell script.
  2. `/My/Path/tiled2unitylite.sh` This is the path to the shell script that will be running Tiled2UnityLite.cs through CS-Script with the arguments that follow. I use a shell script because I need a bit of help controlling the environment variables of the system (they are different when you launch an app as opposed to using the terminal).
  3. `%mapfile` Tiled will replace this with the full path of the TMX file currently in focus.
  4. `/MyProject/Assets/Tiled2Unity` The path to the Tiled2Unity folder in the Unity project you want to export to.

The `tiled2unitylite.sh` shell script is pretty standard fare:

<pre class="brush: bash; title: ; notranslate" title="">#!/bin/sh

THIS_DIR=`dirname $0`
pushd $THIS_DIR &gt; /dev/null 2&gt;&1

CSSCRIPT_DIR=/usr/share/CS-Script
mono $CSSCRIPT_DIR/cscs.exe -nl Tiled2UnityLite.cs "$@" &&gt; tiled2unitylite.log

popd &gt; /dev/null 2&lt;&1</pre>

You'll note that I'm redirecting the output from `Tiled2UnityLite.cs` into a `tiled2unitylite.log` file (_Quick note: You will have to create this log file before running the script_). This helps me track down any errors that may be reported. I use the the `tail` command in another terminal so that I can track export progress in real time.

<pre class="brush: plain; title: ; notranslate" title="">tail -f tiled2unitylite.log</pre>

With everything finally configured I'm able to, on a Mac, press F5 to export a Tiled map into Unity. Here's a quick example from one of my most cherished memories in gaming history that old school gamers will quickly recognize.

<div id="attachment_1097" style="width: 630px" class="wp-caption alignnone">
  <a href="/assets/wp-content/uploads/2015/12/mother-brain-tiled.png" rel="attachment wp-att-1097"><img class="size-full wp-image-1097" src="/assets/wp-content/uploads/2015/12/mother-brain-tiled.png" alt="Mother Brain Lair in Tiled" width="620" srcset="/assets/wp-content/uploads/2015/12/mother-brain-tiled.png 1090w, /assets/wp-content/uploads/2015/12/mother-brain-tiled-300x165.png 300w, /assets/wp-content/uploads/2015/12/mother-brain-tiled-768x423.png 768w, /assets/wp-content/uploads/2015/12/mother-brain-tiled-1024x564.png 1024w" sizes="(max-width: 1090px) 100vw, 1090px" /></a>
  
  <p class="wp-caption-text">
    In Tiled, I can press F5 to execute a command on the currently loaded map. In this example that command will export the map, through Tiled2UnityLite, to my Unity project.
  </p>
</div>

<div id="attachment_1098" style="width: 630px" class="wp-caption alignnone">
  <a href="/assets/wp-content/uploads/2015/12/mother-brain-unity.png" rel="attachment wp-att-1098"><img class="size-full wp-image-1098" src="/assets/wp-content/uploads/2015/12/mother-brain-unity.png" alt="Mother Brain Lair - Unity" width="620" srcset="/assets/wp-content/uploads/2015/12/mother-brain-unity.png 1371w, /assets/wp-content/uploads/2015/12/mother-brain-unity-300x163.png 300w, /assets/wp-content/uploads/2015/12/mother-brain-unity-768x418.png 768w, /assets/wp-content/uploads/2015/12/mother-brain-unity-1024x557.png 1024w" sizes="(max-width: 1371px) 100vw, 1371px" /></a>
  
  <p class="wp-caption-text">
    Once exported to Unity, I can put the constructed prefab into my scene. As you can see, the tile layers and colliders have been successfully imported.
  </p>
</div>

## Now Accepting Donations for Tiled2Unity Development

Perhaps this is hard to believe but pleased Tiled2Unity users do ask if they could thank me for this tool by making a small monetary contribution. In the past I've asked them to support the [Tiled Map Editor Patreon](https://www.patreon.com/bjorn?ty=h) instead (**which is still a priority, support that first!**) but I do believe that Tiled2Unity has now matured into a valuable piece of software. **Tiled2Unity will always be free** but if you'd like to send a small gift my way [I will accept it]({{ '/donate/' | relative_url }}) with pride and appreciation.

And on a personal note, with the new year just a few hours away, I wish you all an enjoyable and _productive_ 2016. Have fun and keep working on your game.