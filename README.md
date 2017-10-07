OCPKatas - Katas for practising the Open-Closed Principle
=========================================================

The 4-minute-history : [cafe-encounter.net/p2158/three-historical-definitions-of-the-openclosed-principle-and-a-claim-that-its-pointless](https://www.cafe-encounter.net/p2158/three-historical-definitions-of-the-openclosed-principle-and-a-claim-that-its-pointless)

tl;dr : "Software entities (classes, modules, functions, etc.) should be open for extension, but closed for
modification"; that is, such an entity can allow its behaviour to be modified without altering its
source code. The paradox is both unavoidable and hard. There have been at least three attempts to (re)define and (re)solve it.

Apparent implication: it should be possible to add functionality to a code base not by modifying
the current code, but only by extending it.

This is particularly important for components that are used by several client components but which
must still be updated without forcing existing clients to be update. In fact this was exactly the 
case that Bertrand Meyer was addressing when he set out the Open-Closed Principle. It's fair to say 
that it's still a significant issue in software.

This repo contains various katas which may help in learning ways of addressing this; and some 
starter-projects for those katas.

Rules for OCP Katas
===================

1. Write the first failing test.
Then write a factory that returns an object, or an aggregate of objects, that make the test pass. The factory 
should be limited to creating objects and linking them together. No conditionals allowed.
1.1 You may refactor until you declare "Ship!" After you've shipped, you can't change the code any more.

2. Write the next failing test.
Can you make it pass by changing the factory and/or creating a new class and nothing else? If yes, great! 
Go back to 1. If not, refactor until you can.

There are 3 options for the Refactoring Rule:

1. The Strict Rule: You should be able to implement each new requirement, not by changing the 
classes/method you have written -- they are considered closed for modification. They should instead be open 
for extension. That is, you can add classes which consume, or use, or inherit from, the existing classes. 
As a concession to the small-scaleness of the spec, if the new requirement is too small to count as a new 
responsibility and you are therefore reluctant to create a new class, you may instead add a new method to 
your existing classes. You must still not alter or somehow subvert the existing methods.

2. The Backwards Compatibility Rule: You may refactor existing code subject to the constraint(s) that 
You must maintain functional and interface compatibility. That is, (1) all existing tests (which represent
your existing clients) must continue to pass unaltered. (2) You must maintain interface compatibility. 
You can 'prove' interface compatbility by creating a named (or numbered) interface for each step. More
extremely you could prove it by 

3. The Wisdom of Hindsight Rule: You may refactor freely in order to reach the point where it’s possible
to implement the next test just by changing the aggregate of objects that is returned by the factory.



Gilded Mall Specs
-----------------

Hello and welcome to team Gilded Mall. As you know, we are a small shopping mall opening in a prime location in a 
prominent city. We will house a growing number of stores, each of which will sell only the finest goods and services. 
We will provide stock management software to all our tenants, catering to their common—and not so common—requirements.

1. All tenants want to record item name and price for all their stock. The stock list must update daily, 
applying to the following rules.
2. The Gilded Dress will reduce the sale price of each item by 25% after it has been in stock for 10 weeks.
3. The Gilded Tin Can sells tinned food. Each can has a sell by date typically about a year from when it 
comes in. When the date passes, the can is unsaleable and must be removed from stock.
4. Everyone needs financial reports. This must show the (1) value of all stock held (2) the cost of 
depreciation (loss in stock value) in the past month.
5. The Gilded Carrot sells fresh vegetables. It must always dispose of stock that it has held for 7 days.
6. The food shops also want their monthly finance report to show the value of stock that was binned in the past month.

Hints, Tips, Notes
------------------

The kata revolves around how you handle the combination of shared and not-shared requirements, so if time is limited don't spend it on getting the pricing rules correct for edge cases.
It's acceptable for your factory to have a factory method named for each shop type (and probably the simplest way to meet the 'No conditionals in the factory' constraint). The challenge will be in how each method assembles its shop from shared components.
Use simple test data. Just one or 2 stock items per shop should suffice.
For the enthusiastic, try it in both a statically typed language and a dynamic one.
