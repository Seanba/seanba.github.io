---
id: 344
title: Fun programming exercises with Project Euler
date: 2009-12-23T01:12:41+00:00
author: Seanba
layout: old-post-deprecated
permalink: /fun-programming-exercises-with-project-euler.html
categories:
  - Uncategorized
excerpt_separator: <!--more-->
---
[<img class="sba-align-left" title="Leonhard Euler, master mathematician" alt="Leonhard Euler" src="/assets/wp-content/uploads/2009/12/euler.jpg" width="108" height="132" />](http://en.wikipedia.org/wiki/Leonhard_Euler)

I don’t know about programmers in the _real world_ but as a video game programmer I often worry about my coding skills getting a little bit stagnant due to our near-universal reliance on C++. And that problem is even worse if you work at one of those places where fancy stuff like templates, the STL, and smart pointers are discouraged (because “they’re slow”, or something) and especially so if inheritance gone wild _is_ encouraged.

<!--more-->

## Yes, again with that Pragmatic Programmer book

People that know me are well aware of my love for [The Pragmatic Programmer](http://pragprog.com/the-pragmatic-programmer). I don’t enjoy going around telling people what to do, nor do I pretend to have the authority to do so, but I think it’s one of those books that should be read by anyone who _enthusiastically_ writes code for a living.

A very popular bit of advice from that book is to **learn a new programming language every year.** I actually only manage to learn a new language every couple of years, but it’s still valuable advice. Learning C#, for instance, was one of the better moves for me as I’ve found more and more game studios are using C# for their tools development.

Lately, I’ve been looking for a good scripting language to add to my repertoire. And by good I mean **not Python or Perl** (tongue firmly implanted in cheek, btw). I actually have extensive experience with Python (most of [Tabula Rasa]({{ '/a-killed-mmo-how-very-rude/' | relative_url }}.html) was written in Python) but I can’t stand the whitespace syntax. And Perl? Well, let’s just say that when it comes to a programming language that I am a _very shallow man_ – and a good personality just isn’t enough.

<img class="sba-align-right" title="Transformers prove that Japan is cool" alt="Autobots and Decepticons fight" src="/assets/wp-content/uploads/2009/12/transformersareawesome.jpg" width="240" height="211" />

So I’ve decided to give this [Ruby](http://www.ruby-lang.org/en/) thing a try, for no other reason than because everyone seems to be talking about it. Besides, it was [invented in Japan](http://en.wikipedia.org/wiki/Yukihiro_Matsumoto). I mean, come on, this is the nation that gave us Sushi, The Transformers, and Nintendo – so you know Ruby has to be awesome. ‘Nuff said. Case closed. _Q.E.D._ 

## But learning a new language can be kind of boring

I find the hardest part of teaching yourself a new programming language is that you need practice – and those first few exercises, on the order of _Hello World_, just aren’t that exciting. It’s kind of like sitting down with a piano teacher and going over the C major scale. Screw that, I want to play [Für Elise](http://en.wikipedia.org/wiki/F%C3%BCr_Elise) already. But I guess you have to go through that boring stuff before you can accomplish something meaningful.

## Project Euler provides cool exercises for programmers

Through [Math-Blog](http://math-blog.com/2009/08/19/improve-your-math-and-programming-skills-with-project-euler/), I have recently discovered a totally cool site for mathematicians and programmers, [Project Euler](http://projecteuler.net/index.php?section=about):

> Project Euler is a series of challenging mathematical/computer programming problems that will require more than just mathematical insights to solve. Although mathematics will help you arrive at elegant and efficient methods, the use of a computer and programming skills will be required to solve most problems.

And here’s the money quote from Math-Blog’s [Antonio Cangiano](http://math-blog.com/about/) explaining how this relates to us folks in search for exciting ways to self-teach a new computer language:

> Finally, if you are a programmer who’s scoping out a new programming language, be it Python, Ruby, Scala, Haskell or Erlang, you’ll find a great ally in Project Euler. Having to write hundreds of programs in a given language, will naturally increase your familiarity with that language. And again, comparing your newcomer coding style with those of more experience participants, will no doubt contribute to your advancement within the given language you’re focusing on.

Right on. For my own part, I just finished my first solution to [Problem #9](http://projecteuler.net/index.php?section=problems&id=9):

> A Pythagorean triplet is a set of three natural numbers, <var>a</var> < <var>b</var> < <var>c</var>, for which, 
> 
> <p align="center">
>   <var>a</var><sup>2</sup> + <var>b</var><sup>2</sup> = <var>c</var><sup>2</sup>
> </p>
> 
> For example, 3<sup>2</sup> + 4<sup>2</sup> = 9 + 16 = 25 = 5<sup>2</sup>.
> 
> There exists exactly one Pythagorean triplet for which <var>a</var> + <var>b</var> + <var>c</var> = 1000.   
> Find the product <var>abc</var>.

**Project Euler** frowns upon just giving out answers on the internet, but I don’t mind saying that a quick look at Wikipedia for [Pythagorean triple generating functions](http://en.wikipedia.org/wiki/Pythagorean_triple#Generating_a_triple) helped me get to a solution that wasn’t _entirely_ brute force, and I learned just a little bit more Ruby in doing so.

<img class="sba-align-left" title="A cool way of visualizing the Pythagorean Theorem" alt="Pythagorean Theorem" src="/assets/wp-content/uploads/2009/12/pythagoreantheorem1.png" width="240" height="191" />

**+1 Math and +1 Ruby?** _Nice_.

 

And what I found really awesome was, after entering the answer key on Project Euler’s website, I was granted access to a special forum for that solution, and was rather, um, _humbled_ by the much more elegant solutions that existed, both in terms of mathematical knowledge and mastery of a given language. **This is very cool stuff for learning.**

## 269 bottles of math on the wall

There are currently 269 problems up in Project Euler to solve but I doubt I’ll ever do more than a dozen or so over time. I have [a ton of other projects]({{ '/rule-32-enjoy-the-little-things/' | relative_url }}.html) on the go and I just want an interesting problem or two to work on as I grasp a new programming language, though if I’m **really** tempted, I just might do enough to become a [Level 1 Eulerian](http://projecteuler.net/index.php?section=scores&level=1). 🙂 

As an enthusiast of both programming and mathematics, **Project Euler has my highest recommendation**. [Check them out](http://projecteuler.net/index.php?section=about).