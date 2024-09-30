# Gilded Rose Refactoring Kata

## The "philosophy" behind my attempt

I broke my attempt of this Kata into three phases: 
**Phase one** was a general cleanup - eg, replacing for with foreach, removing magic numbers/strings, introducing some private methods, reducing nesting in ifs etc. It also introduced some extra unit tests to make changes safer. All this made things more readable, allowing me to see the wood for the trees, so to speak, to then attempt further phases.
**Phase two** was then to pull out logic that referred directly to an item name from the `GildedRose` class and into extension methods on the `Item` class (my way of pretending I could change the class itself) - this meant that the `UpdateQuality` method doesn't need to know anything about a specific item, but instead just has to understand the generic properties that all items have.
**Phase three** then takes this further and changes the program to inject pretty much all item-specific details as a set of data structures - the exact parameters by which `Quality` is altered as each day passes is then represented by rule objects that relate to a given item type. This means that no logic should need to change to introduce a new item that has, for example, a different rate of daily quality change. 
Note that as of the time of writing this change has not yet been merged back to master as I'd typically want this type of more fundamental change reviewing before commiting it; but it can be found in this PR: https://github.com/ChrisClark303/GildedRose/pull/7. The tests do pass so it can be seen that the code is working as expected.
There are still some issues in this approach - for example, Min and Max Quality are still hardcoded in the `ItemExtensions` class, and it would be nice to data-drive these - so there is still work that can be done.

## How to use this Kata

The first thing to do is make a copy of this repository in your personal GitHub account and make public. Please do not fork this repository as your solution will be visible to others undertaking this exercise.

The purpose of this exercise is to demonstrate your skills at designing test cases and refactoring a legacy codebase, safely. 

The idea is not to re-write the code from scratch, but rather to practice taking small steps, running the tests often, and incrementally improve the design towards a solution that embodies OO principles and patterns.


## Gilded Rose Requirements Specification

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a
prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods.
Unfortunately, our goods are constantly degrading in `Quality` as they approach their sell by date.

We have a system in place that updates our inventory for us. It was developed by a no-nonsense type named
Leeroy, who has moved on to new adventures. Your task is to add the new feature to our system so that
we can begin selling a new category of items. First an introduction to our system:

- All `items` have a `SellIn` value which denotes the number of days we have to sell the `items`
- All `items` have a `Quality` value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, `Quality` degrades twice as fast
- The `Quality` of an item is never negative
- __"Aged Brie"__ actually increases in `Quality` the older it gets
- The `Quality` of an item is never more than `50`
- __"Sulfuras"__, being a legendary item, never has to be sold or decreases in `Quality`
- __"Backstage passes"__, like aged brie, increases in `Quality` as its `SellIn` value approaches;
	- `Quality` increases by `2` when there are `10` days or less and by `3` when there are `5` days or less but
	- `Quality` drops to `0` after the concert

We have recently signed a supplier of conjured items. This requires an update to our system:

- __"Conjured"__ items degrade in `Quality` twice as fast as normal items

Feel free to make any changes to the `UpdateQuality` method and add any new code as long as everything
still works correctly. However, do not alter the `Item` class or `Items` property as those belong to the
goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code
ownership (you can make the `UpdateQuality` method and `Items` property static if you like, we'll cover
for you).

Just for clarification, an item can never have its `Quality` increase above `50`, however __"Sulfuras"__ is a
legendary item and as such its `Quality` is `80` and it never alters.


## Introduction to Text-Based Approval Testing
This is a testing approach which is very useful when refactoring legacy code. Before you change the code, you run it, and gather the output of the code as a plain text file. You review the text, and if it correctly describes the behaviour as you understand it, you can "approve" it, and save it as a "Golden Master". Then after you change the code, you run it again, and compare the new output against the Golden Master. Any differences, and the test fails.

It's basically the same idea as "assertEquals(expected, actual)" in a unit test, except the text you are comparing is typically much longer, and the "expected" value is saved from actual output, rather than being defined in advance.

Typically a piece of legacy code may not produce suitable textual output from the start, so you may need to modify it before you can write your first text-based approval test. This has already been setup and the initial "Golden Master" has been provided in `ApprovalTest.ThirtyDays.verified.txt`
