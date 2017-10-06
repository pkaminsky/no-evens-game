# no-evens-game
cross-platform IQ puzzles in monogame

## Summary & No-License Info

This is some code for a videogame I'm tinkering with, currently just for fun. I want to make the code available to the DIY game dev community, for self-taught programmers seeking examples to learn from or to help sort through problems. I do not officially grant any license for re-use of this code, or any guarantees about it.

## What is the game?

The game is a brain teaser type of game based on point-and-click assemblage of valid groups of items which meet certain defined constraints based on their properties. For example, you must find groups of 3 similarly-colored owls from a large flock of them.

As of the initial commit, the basic logic and functionality exists, but there isn't much game other than a functional demo stage.

I use a cross-platform monogame target for desktop systems but the plan is to run on Mobile, PC and Mac, possibly Linux.

## Can I make the code run?

The code is provided for example purposes so I do not intend that you can download and run the game; instead I expect that you would just browse the repo on the web. If you wanted to, here's what you'd need.

The projects use the newer Visual Studio 2017 format. 

I do not provide any of the graphics content, so the app will not run. To make it run, you would either need to add graphics matching all the content names. If you really had a valid reason to want to run this, I may be willing to provide the .mgcb file which has all the graphics content.

Additionally, you will probably need LilyPath. LilyPath is/was not available as NuGet package, so I pulled the source code from GitHub and manually referenced it in the .Sln. You'd also probably need to tweak the project file.