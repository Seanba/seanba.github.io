---
id: 625
title: Mega Man in Unity
date: 2014-03-16T22:01:07+00:00
author: Seanba
layout: old-post-deprecated
permalink: /mega-man-in-unity.html
thesis_description:
  - The Cutman stage of the original Mega Man game remade in the Unity3D engine.
thesis_keywords:
  - MegaMan Cutman Unity3D Unity
categories:
  - Uncategorized
---
[<img title="Mega Man in Unity" alt="Mega Man in Unity" src="/assets/wp-content/uploads/2014/03/mm-unity.png" width="640" height="240" />]({{ '/unity/mm/MMvsCM-mf/' | relative_url }}.html "Mega Man in Unity")

After shipping [Epic Mickey 2](http://en.wikipedia.org/wiki/Epic_Mickey_2:_The_Power_of_Two) (and before the heartbreaking closure of [Junction Point Studios](http://en.wikipedia.org/wiki/Junction_Point_Studios)) I had a couple of months of comp time to unwind and sharpen the saw a bit.

I decided to spend my some time during that break getting to know the [Unity game engine](https://unity3d.com/).

To be honest, I had to fight some strong biases in starting that exercise. I’m not sure how widely known the following sentiment is, but for programmers in big-budget, high-end AAA game development the idea of using an engine like Unity is considered weak sauce. Better to spend your time in C++ learning more about concurrency and data object model programming.

But I’ve been longing for some technology to help me prototype gaming ideas quickly and it sounded like Unity was the best contender.

I also decided that this would be the first time in my double life as a hobbyist game programmer that I was actually going to finish something. To that point I chose a beloved game from my childhood and decided to remake, in part, the original [Mega Man from the NES golden days](http://en.wikipedia.org/wiki/Mega_Man_(video_game)). I figured my love for the franchise would help get me past the eventual malaise that smothers every hobby project of mine once real life kicks in.

I’ve just recently finished the exercise and [you can play the game in your browser here …]({{ '/unity/mm/MMvsCM-mf/' | relative_url }}.html)

[<img title="Mega Man in Unity" alt="Mega Man in Unity" src="/assets/wp-content/uploads/2014/03/mm-vs-cm.png" width="640" height="460" />]({{ '/unity/mm/MMvsCM-mf/' | relative_url }}.html "Mega Man Versus Cutman")

## Only Cutman’s Stage

Like most old-time gamers I’ve spoken to, my experience with Mega Man started with Cutman’s stage &#8212; so that is the focus for this game. Other limitations on this Unity-powered game include …

  * Mega Man has **no additional powers** from any Robot Masters. The Mega Buster is his only weapon.
  * Enemies do not drop powerups, free lives, or any other items.
  * There is no scoring.

Obviously this is not a _complete_ Mega Man game but fans of the original title will hopefully appreciate the 10 minutes or so of oldschool gameplay.

And fellow hobbyists might appreciate that this was accomplished with the **free version of Unity**.

## Some Assembly Was Required

Still, with Unity being a 3D engine there were two important technologies I spent time on in order to display 2D assets:

  1. **Sprites:** I used the freely-available [SpriteManager](http://wiki.unity3d.com/index.php?title=SpriteManager "SpriteManager") utility for sprite animation. In addition, I wrote a utility that took animations from [GraphicsGale](http://www.humanbalance.net/gale/us/ "GraphicsGale") and generated code and data for each sprite.
  2. **Tile-based Maps:** I wrote a utility that transformed map data from [Tiled Map Editor](http://www.mapeditor.org/ "Tiled Map Editor") (a great little program for 2D enthusiasts, btw) into a [Wavefront OBJ file](http://en.wikipedia.org/wiki/Wavefront_.obj_file "Wavefront Obj File") that could be imported into Unity.

Ironically, I finished this project just as [Unity 4.3](http://unity3d.com/unity/whats-new/unity-4.3) was being released so there’s a good bit of work here (especially with the sprites) I was planning to use for other titles that is now obsolete. That’s okay though as I’d much rather see sprites being first class citizens within Unity anyhow.

## Was it Time Well Spent?

I started this project in December of 2012 and within a couple of weeks I pretty much had everything in place, with Mega Man running and jumping around Cutman’s level and a couple of the enemy sprites doing their thing. I was (and still am) pleased with how easy it is to work with Unity, even when you are trying to do something that game engine wasn’t really built for, like 2D sprite-based gaming.

After that short time I could have (and maybe should have) moved on to something original as the exercise of “learning” Unity was accomplished &#8212; but what I can say, I love that little Blue Bomber dude. I had fun with this.

**How long did this take?** It’s hard to say as I don’t do project management on my hobbies (what a depressing concept!). Yes, I started this nearly a year-and-a-half ago, but man, I also had to layoff some 30 of my closest programmer friends, shut down a studio, and find another job in that time as well. I only worked on this in spurts. Now, I’m just happy with the end result and I’m eager to focus on something else with my spare time. **I hope some Mega Man fans give it a try and enjoy a small piece of nostalgia too.**

**And as far as Unity goes**: I use it for all my hobby game programming projects now. I’d like to see the 2D components mature some more (Unity 4.3 is a great start to that) but overall I can’t think of any other (free) game engine that comes close to this one.

<div class="sba-footnotes">
  <p>
    <strong>NOTE:</strong> I feel I should apologize for the occasional jittery scrolling and screen tearing in the playable Unity game. This appears to be an issue with the Web Player that other developers struggle with and as far as I’ve researched there’s no easy solution. If I’m wrong, <a href="mailto:sean@seanba.com">email me the details</a>. I’ll gladly fix it.
  </p>
  
  <p>
    &nbsp;
  </p>
  
  <p>
    I’m embarrassed I didn’t realize it would be a problem until after the game was complete as I should have tested on the Web Player throughout development. That’s a total rookie mistake there.
  </p>
</div>