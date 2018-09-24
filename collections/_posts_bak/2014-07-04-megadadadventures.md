---
id: 771
title: The Real-Life Adventures of Mega Dad with Tiled2Unity
date: 2014-07-04T16:20:57+00:00
author: Seanba
layout: old-post-tiled2unity
permalink: /megadadadventures.html
---
<a title="Mega Dad Adventures" href="{{ '/unity/tiled2unity/MegaDadAdventures/' | relative_url }}.html" target="_blank" rel="Mega Dad Adventures"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="The Real Life Adventures of MegaDad" src="/assets/wp-content/uploads/2014/07/megadad-adventures.png" alt="The Real Life Adventures of MegaDad" width="640" height="180" border="0" /></a>

(**Note:** All the examples in this post are <a title="Mega Dad Adventures" href="{{ '/unity/tiled2unity/MegaDadAdventures/' | relative_url }}.html" target="_blank" rel="Mega Dad Adventures">playable in the Unity Web Browser here</a>.)

I recently introduced my <a title="Tiled2Unity" href="{{ '/introtiled2unity/' | relative_url }}.html" rel="Tiled2Unity">Tiled2Unity Utility</a> where I showed how to get started with Unity2Tiled and walked us through a couple of simple examples.

**Now I want to show off some actual gameplay.** In these examples we’ll see how a “real” game could interact with our exported Tiled maps. We’ll be introduced to concepts like setting Unity Tags and Layers automatically and reacting to colliders. I’ll show you how I achieve tile map animation and how you can hook into the Tiled2Unity import scripts to add custom behavior to your exported map layers and objects.

I keep these same goals in mind with these examples:

  * Exporting should be easy
  * Once exported, your prefabs should work without further tweaking – you just place them in the scene and you’re done

## A Quick Word on Character Controllers (and Mega Dad)

<img class="left-image-tight" style="background-image: none; padding-top: 0px; padding-left: 0px; padding-right: 0px; border-width: 0px;" title="Mega Dad" src="/assets/wp-content/uploads/2014/06/mega-dad-stand.png" alt="Mega Dad" width="42" height="48" border="0" />The focus of these tutorials is Tiled map files in Unity through Tiled2Unity but I did invest some time in a 2D platform character controller using the <a title="CharacterController2D" href="https://github.com/prime31/CharacterController2D" rel="CharacterController2D">CharacterController2D</a> provided by [prime[31]](https://prime31.com/plugins "Prime[31]") as a starting point.

Also, this work is strongly influenced by the [Mega Man franchise](http://en.wikipedia.org/wiki/Mega_Man "Mega Man") of the NES golden-age. This will not surprise anyone that knows me. My daughters, being well-aware of my affinity for Mega Man, have taken to calling me Mega Dad at times so my hobbyist programming often includes the sprite I’ve made for the nickname.

## Get the Tutorial Files

All the scripting, art, and Tile source files (TMX format) used for these examples is available on GitHub here:

  * <https://github.com/Seanba/Tiled2Unity-MegaDad>

This project contains two sections:

  1. The Unity project source containing all the functionality and scripting found in this tutorial.
  2. The <a title="Tiled Map Editor" href="http://www.mapeditor.org/" target="_blank" rel="Tiled Map Editor">Tiled Map Editor</a> TMX source files. These were exported into the Unity project through Tiled2Unity.

## Simple Example: No Collision or Gameplay

The simplest use of Tiled2Unity involves a decorative Tiled map in your Unity project. For this, I’m using Magma Man’s lair from <a title="Mega Man 9" href="http://en.wikipedia.org/wiki/Mega_Man_9" target="_blank">Mega Man 9</a> represented here in Tiled map form …

[<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Magma Man - No Collision" src="/assets/wp-content/uploads/2014/06/tiled-magma-man-nocol_thumb.jpg" alt="Magma Man - No Collision" width="640" height="512" border="0" />](/assets/wp-content/uploads/2014/06/tiled-magma-man-nocol.jpg)

There’s nothing special about this and no preparation is needed before export. You can find it in the `simple-no-collision` scene in the example where it just sits there with a camera on it.

## Simple Example with Collision

For the Tiled file `MagmaManLair-WithCollision.tmx` I’ve used the **Tile Collision Editor** to add collision to all the tiles that I’d expect our playable character to collide with.

[<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Simple Map with Collision" src="/assets/wp-content/uploads/2014/06/tiled-magma-man-withcol_thumb.jpg" alt="Simple Map with Collision" width="644" height="520" border="0" />](/assets/wp-content/uploads/2014/06/tiled-magma-man-withcol.jpg)

Using the Tiled2Unity previewer I can see how the collisions would appear in Unity before I export.

[<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Magma Man Collision Preview" src="/assets/wp-content/uploads/2014/06/t2u-preview-magma_thumb.png" alt="Magma Man Collision Preview" width="342" height="348" border="0" />](/assets/wp-content/uploads/2014/06/t2u-preview-magma.png)

I purposely chose a screen from one of the Mega Man games that had some interesting collision in it to show the kind of complexity that Tiled2Unity can handle. We can see the exported results in the `simple-with-collision` scene. This scene introduces our Mega Dad sprite as well. You can move him around with the arrow keys and jump with spacebar and see that he’s colliding with the `PolygonCollider2D` geometry as we’d expect from a Mega Man type game.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Playing the Magma Man Lair scene" src="/assets/wp-content/uploads/2014/06/uni-magma-play.jpg" alt="Playing the Magma Man Lair scene" width="512" height="224" border="0" />

Note that all exported layers and objects are, by default, assigned the `Default` physics layer but we could change that if we wanted to (and will later with more complicated scenes). Since our Mega Dad sprite is set up to collide with `Default` physics we don’t need to make any changes yet.

## Collision with Slopes

The collision geometry from the last example is actually one `PolygonCollider2D` object but it looks a bit boxy and doesn’t demonstrate the flexibility we have with the shapes of colliders we can use with Tiled2Unity.

There are no examples of sloped collision in the Mega Man NES games so for this example I’m going to borrow art from <a title="Strider (NES)" href="http://en.wikipedia.org/wiki/Strider_(NES_video_game)" target="_blank">Capcom’s NES port of Strider</a> &#8212; which had plenty of sloped terrain in it.

Here you can see the `RedDragon-WithSlopes.tmx` file open in Tiled with one of the tiles having a single triangle-polygon on it for collision …

[<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Sloped Collision" src="/assets/wp-content/uploads/2014/06/tiled-slopes_thumb.jpg" alt="Sloped Collision" width="640" height="515" border="0" />](/assets/wp-content/uploads/2014/06/tiled-slopes.jpg)

And again, the Tiled2Unity previewer …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Slopes Preview" src="/assets/wp-content/uploads/2014/06/t2u-preview-slopes.png" alt="Slopes Preview" width="336" height="345" border="0" />

This map was exported and added to the `slopes` scene in the downloadable example. Here you can see Mega Dad standing on the sloped terrain.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Sloped Collision in Play" src="/assets/wp-content/uploads/2014/06/uni-sloped-play.jpg" alt="Sloped Collision in Play" width="512" height="224" border="0" />

Games with such terrain in them usually build their sprites with this in mind so they look better on a slope, but I think you get the idea.

Still, we can make this better through using Tiled2Unity’s ability to set the Sorting Layer on an exported Tiled layer.

## Sorting Layer and Order in Layer Properties

As you can see, Mega Dad looks a bit awkward when not on even ground …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Mega Dude Hanging" src="/assets/wp-content/uploads/2014/06/mega-dude-hang.png" alt="Mega Dude Hanging" width="192" height="172" border="0" />

Games generally handle this by changing their sprite artwork or by changing their environment  to give it more depth or by using the foreground to hide the sprite’s feet.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Slope Examples" src="/assets/wp-content/uploads/2014/06/slope-examples.png" alt="Slope Examples" width="600" height="164" border="0" />

Taking a cue from <a title="Super Metroid" href="http://en.wikipedia.org/wiki/Super_Metroid" target="_blank">Super Metroid</a>, I’m going to put some railing _in the foreground_ over our slopes.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Slope, with rails" src="/assets/wp-content/uploads/2014/06/slope-with-railing.png" alt="Slope, with rails" width="512" height="224" border="0" />

Adding this to our map in Tiled is easy enough but now we’re doing something new with our scene in Unity: **We need to render our sprite between two Tiled layers.**

By default, Tiled layers are exported with the `Default` sort layer. Now we’ll want to purposely assign sorting layers. This Unity project has the following sorting layers in order:

  1. Background
  2. Default
  3. Foreground

(Our Mega Dad sprite renders to the Default sort layer in this example)

Each layer or object in Tiled supports custom properties and in order to change our Sorting Layer we add a custom property named `unity:sortingLayerName` to our layers.

Putting our **Background** Tiled layer in the Background sorting layer …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Background Sorting Layer" src="/assets/wp-content/uploads/2014/06/uni-prop-background.jpg" alt="Background Sorting Layer" width="261" height="197" border="0" />

And putting our **GuardRails** Tiled layer in the Foreground sorting layer …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Foreground Sorting Layer" src="/assets/wp-content/uploads/2014/06/uni-prop-rails.jpg" alt="Foreground Sorting Layer" width="257" height="185" border="0" />

… we construct a prefab on export that hides our Mega Dad’s feet behind the foreground while he’s standing on a slope.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Hiding odd looking collision" src="/assets/wp-content/uploads/2014/06/uni-sort-layer.jpg" alt="Hiding odd looking collision" width="512" height="448" border="0" />

Here’s the list of the properties we can set in Tiled that the Tiled2Unity exporter looks for when constructing a prefab:

  * `unity:tag`
  * `unity:sortingLayerName`
  * `unity:sortingOrder`
  * `unity:layer` (Layer is such an overloaded term. In Unity it means the “physics” layer.)

We often don’t want to set `unity:sortingOrder` as it is implicitly set for you by the order of Tiled layers in your TMX file. We’ll use `unity:tag` and `unity:layer` in interesting ways soon.

Note that should you try to use a Sorting Layer Name that does not exist in your Unity project that the importer scripts in Unity will let you know about it through an error in the Unity console:

`<span style="color: #ff0000;">Sorting Layer "Foreground" does not exist. Check your Project Settings -> Tags and Layers</span>`

<span style="color: #000080;"><strong>Important Update:</strong> With Tiled2Unity 1.0.5.0 and later you no longer need to use the <code>unity:layer</code> property. Instead, use the <code>Type</code> field of your rectangles, polygons, and polylines in the Tile Collision Editor. This <code>Type</code> will match the physics layer in your Unity project.</span>

## Adding Gameplay with Tags

This next example is probably my favorite as the `water` scene in the Unity project is a good example of bringing Tiled maps to life in your Unity project.

Getting back into the Mega Man look and feel, the `DiveMan-water.tmx` Tiled map file borrows from the Dive Man stage of <a title="Mega Man 4" href="http://en.wikipedia.org/wiki/Mega_Man_4" target="_blank">Mega Man 4</a>. You’ll notice the Tiled layers are animating (**Update:** Animations are supported in Tiled now and later versions of Tiled2Unity will export those animations as-is. There is no longer a need for additional scripting to pull this off.)

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Animating Tile Layers" src="/assets/wp-content/uploads/2014/06/uni-diveman.gif" alt="Animating Tile Layers" width="256" height="240" border="0" />

This is achieved in Unity scripting by simply selecting game objects based on their tags (**AnimLayer1** and **AnimLayer2**) and toggling between them at a given framerate.

<pre class="brush: csharp; gutter: false;">// A cheap an easy class that animates our Tiled layers

class LayerAnimator : MonoBehaviour

{

    public float TimePerLayer = 0.5f;



    private void Start()

    {

        StartCoroutine(AnimateRoutine());

    }



    private IEnumerator AnimateRoutine()

    {

        bool isLayer1Active = true;

        var layer1Objs = GameObject.FindGameObjectsWithTag("AnimLayer1");

        var layer2Objs = GameObject.FindGameObjectsWithTag("AnimLayer2");



        while (true)

        {

            foreach (var obj1 in layer1Objs)

            {

                obj1.SetActive(isLayer1Active);

            }

            foreach (var obj2 in layer2Objs)

            {

                obj2.SetActive(!isLayer1Active);

            }



            isLayer1Active = !isLayer1Active;

            yield return new WaitForSeconds(TimePerLayer);

        }

    }

}</pre>

All this script requires is that we have objects in our scene with the appropriate tags. This is where `unity:tag` comes in.

In Tiled, all we need to do is select the Tiled layers we want to toggle between and give them the `AnimLayer1` or `AnimLayer2` tag. For instance …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Setting Unity Tag" src="/assets/wp-content/uploads/2014/06/tiled-anim-tag.jpg" alt="Setting Unity Tag" width="259" height="196" border="0" />

Once exported, our `LayerAnimator` component in the scene finds the `GameObject`s on our prefab and animates them.

## Adding Gameplay with (Physics) Layers

Also in this example we have gravity changing for Mega Dad when he is inside water. Like the Mega Man games, this will slow his fall and allow him to jump much higher while in water.

This is achieved by having one of the Tiled layers (`WaterVolume`) being exported with the `Water` physics layer (again, I apologize for the overuse of the word ‘layer’ &#8212; it means different things in Unity and Tiled). We use a `unity:layer` custom property within Tiled …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Layer Property" src="/assets/wp-content/uploads/2014/06/tiled-layer-prop.jpg" alt="Layer Property" width="259" height="219" border="0" />

Now all the tiles in this Tiled Layer with collision on them will be be gathered into a `PolygonCollider2D` with the Water physics layer.

Our Character Controller for Mega Dad is set up with a trigger that detects when it is in a water collider and changes Mega Dad’s response to gravity. We also tell Mega Dad to start breathing out air bubbles while within this collider in addition to spawning a “splash” sprite when he enters or exits the collider. It’s a nice example of interacting with maps exported with Tiled2Unity.

[<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Water Trigger" src="/assets/wp-content/uploads/2014/06/uni-diveman-water_thumb.jpg" alt="Water Trigger" width="512" height="448" border="0" />](/assets/wp-content/uploads/2014/06/uni-diveman-water.jpg)

## Tiled Object Layers Can Have Colliders Too

Keeping with the water scene example, there are no tiles with collision off the upper left and right side of that map and we’d like to keep Mega Dad from falling out of the world with _invisible_ collision. That’s where we can use the **Object Layer** features of Tiled which are, like **Tile Layers**, exported into the prefab hierarchy as `GameObject`s.

In this case, Tiled2Unity does not attempt to combine geometry into one collider. Since we are placing Rectangles, Ellipses, Polygons, and Polylines in Tiled separately they are themselves exported as separate `GameObject`s.

  * A Tiled rectangle object is exported as a `BoxCollider2D`
  * An Tiled ellipse object is exported as a `CircleCollider2D` (but only if it is a circle with equal width and height, Unity does not support ellipses)
  * A Tiled polygon object is exported as a `PolygonCollider2D`
  * A Tiled polyline object is exported as an `EdgeCollider2D`

To keep Mega Dad inside the level, I’ve added two rectangle objects to an Object Layer in the TMX file:

[<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Adding Tiled Objects" src="/assets/wp-content/uploads/2014/06/tiled-water-objects_thumb.jpg" alt="Adding Tiled Objects" width="640" height="469" border="0" />](/assets/wp-content/uploads/2014/06/tiled-water-objects.jpg)

Like other collisions we can see what they look like in the Tiled2Unity previewer …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Object Previewer" src="/assets/wp-content/uploads/2014/06/t2u-preview-objects.jpg" alt="Object Previewer" width="400" height="445" border="0" />

Once exported that gives us collision along the sides of our scene so that Mega Dad doesn’t fall out.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="BoxCollider2D Blocking Player" src="/assets/wp-content/uploads/2014/07/uni-water-blocked.png" alt="BoxCollider2D Blocking Player" width="512" height="448" border="0" />

### Ladders With Custom Importing

One of the hard-learned lessons from my <a title="Mega Man game made in Unity" href="{{ '/mega-man-in-unity/' | relative_url }}.html" target="_blank">Mega Man vs Cut Man</a> experiment is what a horrible pain in the ass ladders are to implement. The in-game mechanics of ladders are left, sheepishly, as an exercise of the reader but at least getting ladder geometry into a game can be made easier with Tiled2Unity.

First, in Tiled, we make a separate Tiled Layer for all ladders in the scene and paint some ladders with tiles.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Making Ladders in Tiled for export to Unity" src="/assets/wp-content/uploads/2014/06/tiled-ladders.png" alt="Making Ladders in Tiled for export to Unity" width="638" height="520" border="0" />

Note that the `ladders` Tiled Layer is given the `Ladders` value for the `unity:layer` property. This will add all ladder collision into a special physics layer for us to manipulate later through custom scripting later but for now we can paint ladders with tiles as we wish in our Tiled map file.

#### **What We Need from Ladders**

Because of the way our Mega Dad character interacts with ladders we need to know, for each ladder instance, the following information:

  * The center-line (or spine) of each ladder
  * The top of each ladder
  * The bottom of each ladder

However, from Tiled2Unity, we get _one_ `PolygonCollider2D` that represents _all_ ladders in the Tiled Layer.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Ladder Have vs Need" src="/assets/wp-content/uploads/2014/06/ladder-want-need.jpg" alt="Ladder Have vs Need" width="640" height="200" border="0" />

We could lay down polylines in Tiled that get exported into `EdgeCollider2D` instances but if we move, add, or remove ladder tiles from our map then we have to manipulate our polylines as well. Instead, we can take advantage of the custom importing feature of Tiled2Unity and write a script that will add the `EdgeCollider2D` instances for us.

### Use ICustomTiledImporter for Custom Importing from Tiled2Unity

Tiled2Unity provides an interface that allows you to add custom behavior to the prefabs it creates from exported Tiled map files. You only need to write a script class that inherits from `ICustomTiledImporter` with the `CustomTiledImporter` attribute. Tiled2Unity will use reflection to find such custom importers and instantiate them as part of the import process. (If order of execution is important use the `Order` property of the `CustomTiledImporter` attribute.)

<pre class="brush: csharp; gutter: false;">// Example custom importer:

[Tiled2Unity.CustomTiledImporter]

class MyCustomImporter : Tiled2Unity.ICustomTiledImporter

{

    public void HandleCustomProperties(GameObject gameObject,

        IDictionary&lt;string, string&gt; keyValuePairs)

    {

        Debug.Log("Handle custom properties from Tiled map");

    }



    public void CustomizePrefab(GameObject prefab)

    {

        Debug.Log("Customize prefab");

    }

}</pre>

&nbsp;

For this example we’re going to use the `CustomizePrefab` method to crack open the `PolygonCollider2D` instances belonging to ladders and add the EdgeCollider2Ds we desire.

<pre class="brush: csharp; gutter: false;">// From CustomTiledImporterForLadders.cs

public void CustomizePrefab(GameObject prefab)

{

    // Find all the polygon colliders in the pefab

    var polygon2Ds = prefab.GetComponentsInChildren&lt;PolygonCollider2D&gt;();

    if (polygon2Ds == null)

        return;



    // Find all *ladder* polygon colliders

    int ladderMask = LayerMask.NameToLayer("Ladders");

    var ladderPolygons = from polygon in polygon2Ds

                         where polygon.gameObject.layer == ladderMask

                         select polygon;



    // For each ladder path in a ladder polygon collider

    // add a top, spine, and bottom edge collider

    foreach (var poly in ladderPolygons)

    {

        GameObject ladderTops = new GameObject("LadderTop-EdgeColliders");

        GameObject ladderSpines = new GameObject("LadderSpine-EdgeColliders");

        GameObject ladderBottoms = new GameObject("LadderBottom-EdgeColliders");

        ladderTops.layer = LayerMask.NameToLayer("LadderTops");

        ladderSpines.layer = LayerMask.NameToLayer("LadderSpines");

        ladderBottoms.layer = LayerMask.NameToLayer("LadderBottoms");



        // Create edge colliders for the ladder tops

        // We assume that every polygon path represents a ladder

        for (int p = 0; p &lt; poly.pathCount; ++p)

        {

            Vector2[] points = poly.GetPath(p);



            float xmin = points.Min(pt =&gt; pt.x);

            float xmax = points.Max(pt =&gt; pt.x);

            float ymax = points.Max(pt =&gt; pt.y);

            float ymin = points.Min(pt =&gt; pt.y);

            float xcen = xmin + (xmax - xmin) * 0.5f;



            // Add our edge collider points for the ladder top

            EdgeCollider2D topEdgeCollider2d =

                ladderTops.AddComponent&lt;EdgeCollider2D&gt;();

            topEdgeCollider2d.points = new Vector2[]

            {

                new Vector2(xmin, ymax),

                new Vector2(xmax, ymax),

            };



            // Add our edge collider points for the ladder spine

            EdgeCollider2D spineEdgeCollider2d =

                ladderSpines.AddComponent&lt;EdgeCollider2D&gt;();

            spineEdgeCollider2d.points = new Vector2[]

            {

                new Vector2(xcen, ymin),

                new Vector2(xcen, ymax),

            };



            // Add our edge collider points for the ladder bottom

            EdgeCollider2D bottomEdgeCollider2d =

                ladderBottoms.AddComponent&lt;EdgeCollider2D&gt;();

            bottomEdgeCollider2d.points = new Vector2[]

            {

                new Vector2(xmin, ymin),

                new Vector2(xmax, ymin),

            };

        }



        // Parent the ladder components to our ladder object

        ladderTops.transform.parent = poly.gameObject.transform;

        ladderSpines.transform.parent = poly.gameObject.transform;

        ladderBottoms.transform.parent = poly.gameObject.transform;

    }

}</pre>

At first glance this may seem like a lot of work, but, once written, this script will now import all ladders for us in all our maps. We can place ladders with ease in Tiled and let the custom importer do all the heavy lifting.

You can see the results of this in the `ladders` scene included in the tutorial Unity package.

[<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="uni-cutman-ladders" src="/assets/wp-content/uploads/2014/06/uni-cutman-ladders_thumb.jpg" alt="uni-cutman-ladders" width="512" height="448" border="0" />](/assets/wp-content/uploads/2014/06/uni-cutman-ladders.jpg)

### Adding Spawners With Custom Import Scripting

With using the Tiled Map Editor as our 2D level editor we often need ways of marking up our worlds with some game-specific behaviors, with spawners for our game sprites being an obvious requirement.

Tiled allows us to place Tile Objects into an Object Layer. Moreover, our Tiles can have custom properties on them. Tiled2Unity allows us, through custom scripting, do get at these custom properties and manipulate the `GameObject`s they are attached to for game-specific behavior.

For this example we’re going to revisit a scene from the popular <a title="Mega Man 2" href="http://en.wikipedia.org/wiki/Mega_Man_2" target="_blank" rel="Mega Man 2">Mega Man 2</a> with the <a title="Appearing Block" href="http://megaman.wikia.com/wiki/Appearing_Block" target="_blank" rel="Appearing Block">Appearing Block</a> sprites from Heat Man’s stage.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Appearing Blocks in Mega Man 2" src="/assets/wp-content/uploads/2014/07/mm2-appearing-blocks.png" alt="Appearing Blocks in Mega Man 2" width="393" height="298" border="0" />

Placing these Appearing Blocks in Tiled is easily achieved by using Tile Objects in an Object Layer. Here I’ve distributed a number of such Tile Objects amongst three Object Layers in the `HeatManBlocks.tmx` file.

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="tiled-blocks" src="/assets/wp-content/uploads/2014/07/tiled-blocks.jpg" alt="tiled-blocks" width="629" height="464" border="0" />

The important part here is with the Tile representing our Appearing Block that we’ve added a custom property `spawn` with the value `AppearingBlock`. We only need to do this once and then we can place as many of those Tile Objects we wish. We’ll write some code soon that consumes those custom property values and, within Unity, will attach `GameObject`s to our map prefab.

Exporting this map into Unity we can see the blocks we’ve placed represented as `GameObject`s in the prefab …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Tile Objects as GameObjects" src="/assets/wp-content/uploads/2014/07/uni-blocks-empty.jpg" alt="Tile Objects as GameObjects" width="290" height="229" border="0" />

… but right now they’re just empty, albeit with the right positional data imported from our Tiled map file.

In order to allow for game-specific importing of map data Tiled2Unity can hook into any custom properties we assign to our map, layer, or object data within our Tiled TMX files. This is achieved through the `HandleCustomProperties` function on the `ICustomTiledImporter` interface that we can inherit from in our Editor scripts. It passes in the dictionary of custom property name and value pairs as well as the `GameObject` that you’ve assigned such custom properties to.

Here’s an example of a custom importer script that looks for a custom `AddComp` property that we have set in Tiled and, during import, will add those components …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Custom Property in Tiled" src="/assets/wp-content/uploads/2014/07/tiled-custom-prop.jpg" alt="Custom Property in Tiled" width="293" height="285" border="0" />

<pre class="brush: csharp; gutter: false;">[Tiled2Unity.CustomTiledImporter]

class CustomImporterAddComponent : Tiled2Unity.ICustomTiledImporter

{

    public void HandleCustomProperties(UnityEngine.GameObject gameObject,

        IDictionary&lt;string, string&gt; props)

    {

        // Simply add a component to our GameObject

        if (props.ContainsKey("AddComp"))

        {

            gameObject.AddComponent(props["AddComp"]);

        }

    }



    public void CustomizePrefab(GameObject prefab)

    {

        // Do nothing

    }

}</pre>

Going back to our example with blocks, what we want to do is look for a `spawn` custom property with a value of `AppearingBlock`, instantiate the appropriate sprite, and then attach it to our game object.

<pre class="brush: csharp; gutter: false;">[Tiled2Unity.CustomTiledImporter]

class CustomTiledImporterForBlocks : Tiled2Unity.ICustomTiledImporter

{



    public void HandleCustomProperties(UnityEngine.GameObject gameObject,

        IDictionary&lt;string, string&gt; props)

    {

        // Does this game object have a spawn property?

        if (!props.ContainsKey("spawn"))

            return;



        // Are we spawning an Appearing Block?

        if (props["spawn"] != "AppearingBlock")

            return;



        // Load the prefab assest and Instantiate it

        string prefabPath = "Assets/Prefabs/AppearingBlock.prefab";

        UnityEngine.Object spawn = 

            AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));

        if (spawn != null)

        {

            // Remove old tile object

            Transform oldTileObject = gameObject.transform.Find("TileObject");

            if (oldTileObject != null)

            {

                GameObject.DestroyImmediate(oldTileObject.gameObject);

            }

 

            // Replace with new spawn object

            GameObject spawnInstance = 

                (GameObject)GameObject.Instantiate(spawn);

            spawnInstance.name = spawn.name;



            // Use the position of the game object we're attached to

            spawnInstance.transform.parent = gameObject.transform;

            spawnInstance.transform.localPosition = Vector3.zero;

        }

    }



    public void CustomizePrefab(UnityEngine.GameObject prefab)

    {

        // Do nothing

    }

}</pre>

Now when we reimport the map we see that our spawned block sprites were added to the prefab hierarchy …

<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Spawned Object in Prefab" src="/assets/wp-content/uploads/2014/07/uni-blocks-spawned.jpg" alt="Spawned Object in Prefab" width="284" height="219" border="0" />

With these spawned sprite objects now in the prefab they can be manipulated by other runtime scripts to add the gameplay we’re looking for – platforming blocks that appear and disappear with a given timed pattern (see the `custom-import` scene to play the example).

[<img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="heatman-blocks" src="/assets/wp-content/uploads/2014/07/heatman-blocks_thumb.png" alt="heatman-blocks" width="512" height="672" border="0" />](/assets/wp-content/uploads/2014/07/heatman-blocks.png)

## 

## Complicated Gameplay with Little Work

These examples may seem a bit involved but I feel it’s a good example of how one could mix unity-specific and custom properties in Tiled with some scripting in your Unity project to achieve behavior that is specialized to the game you are creating. (It actually took me a lot longer to document the examples in this blog post than it did to build this Unity project.)

Any questions? Found a bug? As always feel free to drop me a line in the comments or [email me](mailto:sean@seanba.com). Happy developing.