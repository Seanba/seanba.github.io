---
id: 534
title: Clever Code != Friendly Code
date: 2010-11-07T23:07:23+00:00
author: Seanba
layout: old-post-deprecated
permalink: /clever-code-friendly-code.html
aktt_notify_twitter:
  - 'yes'
thesis_title:
  - Seanba | Clever Code != Friendly Code
thesis_description:
  - Programmers should opt to write code that is understandable, not clever.
thesis_keywords:
  - C++ STL mem_fun bind2nd for_each
aktt_tweeted:
  - "1"
categories:
  - Uncategorized
---
The other day I was looking at some old code I’ve written.

Ugh.

Now, I tend to agree with Jeff Atwood’s [Suck Less Every Year](http://www.codinghorror.com/blog/2006/03/sucking-less-every-year.html) mantra when he says:

> You _should_ be unhappy with code you wrote a year ago. If you aren't, that means either A) you haven't learned anything in a year, B) your code can't be improved, or C) you never revisit old code. All of these are the kiss of death for software developers.

But it’s strange how even the “good” or “smart” code from times gone by has a horrible code smell to it now.

Case in point:

<div style="line-height: 1em; font-family: consola, courier new; margin-bottom: 1em; background: #f9f9ff; color: black; font-size: 14px; border: #0000ae 1px dashed; padding: 1em;">
  <p style="margin: 0px;">
    <span style="color: #0000ff;">using namespace</span> std;
  </p>
  
  <p style="margin: 0px;">
    for_each(obsFirst, obsLast, bind2nd(mem_fun(&Observer::LightMoved), light));
  </p>
</div>

Quick - what does that code above perform? Unless you’re an old-school [Standard Template Library](http://en.wikipedia.org/wiki/Standard_Template_Library) user (the usage has been simplified with [Technical Report 1](http://en.wikipedia.org/wiki/Technical_Report_1)) then you’re probably going to have to look something up.

`std::for_each` is itself easy enough to grok:

<div style="line-height: 1em; font-family: consola, courier new; margin-bottom: 1em; background: #f9f9ff; color: black; font-size: 14px; border: #0000ae 1px dashed; padding: 1em;">
  <p style="margin: 0px;">
    <span style="color: #0000ff;">using namespace</span> std;
  </p>
  
  <p style="margin: 0px;">
    for_each(first, last, someFunction);
  </p>
</div>

This simply invokes a function or function object (anything supporting the parentheses operator) for each object within the range from `first` to `last`, passing in the object as an argument to `someFunction`.

But say you need to pass in two arguments to the function called? Then you’ll need `std::bind2nd`.

<div style="line-height: 1em; font-family: consola, courier new; margin-bottom: 1em; background: #f9f9ff; color: black; font-size: 14px; border: #0000ae 1px dashed; padding: 1em;">
  <p style="margin: 0px;">
    <span style="color: #0000ff;">using namespace</span> std;
  </p>
  
  <p style="margin: 0px;">
    for_each(first, last, bind2nd(someFunction, arg2));
  </p>
</div>

This will call `someFunction(arg1, arg2)`, getting each instance of `arg1`  from the range of `first` to `last`.

Actually, that code above won’t compile, because `std::bind2nd`  requires, as its first argument, a functor object with particular class traits, so we have to wrap the function appropriately with an adaptor.

<div style="line-height: 1em; font-family: consola, courier new; margin-bottom: 1em; background: #f9f9ff; color: black; font-size: 14px; border: #0000ae 1px dashed; padding: 1em;">
  <p style="margin: 0px;">
    <span style="color: #0000ff;">using namespace</span> std;
  </p>
  
  <p style="margin: 0px;">
    for_each(first, last, bind2nd(ptr_fun(someFunction), arg2));
  </p>
</div>

You can see things are starting to get complicated here. Now say you don’t want to call a free function for each object in a range with a second argument, but rather a member function on the object. That’s why `std::mem_fun` is needed, to wrap a member function into a form needed by `std::bind2nd.`

<div style="line-height: 1em; font-family: consola, courier new; margin-bottom: 1em; background: #f9f9ff; color: black; font-size: 14px; border: #0000ae 1px dashed; padding: 1em;">
  <p style="margin: 0px;">
    <span style="color: #0000ff;">using namespace</span> std;
  </p>
  
  <p style="margin: 0px;">
    for_each(first, last, bind2nd(mem_fun(&Foo::SomeMemberFunction), arg2));
  </p>
</div>

**Yuck, what a mess!** But written another way, this is exactly what that code above does …

<div style="line-height: 1em; font-family: consola, courier new; margin-bottom: 1em; background: #f9f9ff; color: black; font-size: 14px; border: #0000ae 1px dashed; padding: 1em;">
  <p style="margin: 0px;">
    for (fooIterator = first; fooIterator != last; ++fooIterator)
  </p>
  
  <p style="margin: 0px;">
    {
  </p>
  
  <p style="margin: 0px;">
        *fooIterator->SomeMemberFunction(arg2);
  </p>
  
  <p style="margin: 0px;">
    }
  </p>
</div>

… which is actually a much better way of explaining the whole eyesore. So why not just write the code that way to begin with and be done with it?

To be honest, I read about `for_each`, `bind2nd`, and `mem_fun` in some book about STL and thought it was pretty clever, so I started a new habit of using those template functions whenever I could.

And, unfortunately for me, the very first time I had a code review with a `for_each`  loop of this fashion in it, the reviewer had these reactions:

  * **First impression:** “What the f\*\*\* is this s\*\*\*?”
  * **After explaining:** “Oh cool, I didn’t even know you could do that with STL.”

I wish he had of just kept with his first impression and told me to rewrite that line of code into something readable, but he was impressed with the new knowledge I shared with him, and I couldn’t help but feel smart about the whole stupid thing.

Funny enough, I was asked to add a code comment though:

<div style="line-height: 1em; font-family: consola, courier new; margin-bottom: 1em; background: #f9f9ff; color: black; font-size: 14px; border: #0000ae 1px dashed; padding: 1em;">
  <p style="margin: 0px;">
    <span style="color: #0000ff;">using namespace</span> std;
  </p>
  
  <p style="margin: 0px;">
     
  </p>
  
  <p style="margin: 0px;">
    <span style="color: green;">// Call observer->LightMoved(light) for all observers</span>
  </p>
  
  <p style="margin: 0px;">
    for_each(obsFirst, obsLast, bind2nd(mem_fun(&Observer::LightMoved), light));
  </p>
</div>

Bleh. I just think that comment makes it all the more obvious that there is something wrong with the code.

## Keep it simple, stupid

There was a time in my development as a programmer where I really cared if people thought I was being clever, and had beguiled myself into thinking that the intelligence of a programmer was best demonstrated by the complexity of his code. I mean, hey, if I’m writing code that just _any_ programmer can easily understand then I mustn’t be that advanced, right? Besides, it’s _their_ job as engineers to keep up on the latest libraries or standards so they can speak _my_ language anyways. Can’t easily understand my code? Pfft … then you mustn’t be very 1337.

I’m embarrassed that I ever used to think that way. **Writing software is hard.** So hard, in fact, that I’d wager a majority of programmers are on software projects that will fail. Some of that failure may be out of our direct influence, but **we can at least control the complexity of our own work**, and make it easy to understand, test, and (gulp) modify by our fellow peers.

The following code may not convince my teammates that I’m particularly smart or gifted …

<div style="line-height: 1em; font-family: consola, courier new; margin-bottom: 1em; background: #f9f9ff; color: black; font-size: 14px; border: #0000ae 1px dashed; padding: 1em;">
  <p style="margin: 0px;">
    for (ObserverList::iterator itr = first; itr != last; ++itr)
  </p>
  
  <p style="margin: 0px;">
    {
  </p>
  
  <p style="margin: 0px;">
        Observer * observer = *itr;
  </p>
  
  <p style="margin: 0px;">
        observer->LightMoved(light);
  </p>
  
  <p style="margin: 0px;">
    }
  </p>
</div>

… but they will at least quickly understand what it does, and perhaps be grateful for that much.