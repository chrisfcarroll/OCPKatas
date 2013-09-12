OCPKatas
========

Katas for practising the Open-Closed Principle

"software entities (classes, modules, functions, etc.) should be open for extension, but closed for
modification"; that is, such an entity can allow its behaviour to be modified without altering its
source code.

Apparent implication: it should be possible to add functionality to a code base not by modifying
the current code, but only by extending it.

This repo contains various katas with starter-projects for those katas.

Kata Rules
==========

<ol start="0"><li>Write the first failing test.</ol>
<ol>
  <li>Then write a <strong>factory</strong> that returns an object, or an aggregate of objects, that make the test pass.
    The factory should be limited to creating objects and linking them together. No conditionals allowed.
  <li>Write the next failing test.
  <li>Can you make it pass by changing the factory and/or creating a new class and nothing else?
    If yes, great! Go back to 1. If not, refactor until you can.
  <p>To clarify: the constraint is that you should be able to implement each new requirement, not by changing the
  classes/method you have written -- they are considered closed for modification.
  They should instead be open for extension. That is, you can <strong>add</strong> classes which consume, or use, or
  inherit from, the existing classes.</p>
  <p>As a concession to the small-scaleness of the spec, if the new requirement is too small to count
    as a new responsibility and you are therefore reluctant to create a new class, you may instead
    add a new method to your existing classes. You must still not alter or somehow subvert the existing
    methods.</p>
  <li>The refactoring should bring the system to a state where it’s possible to implement
    the next test just by changing the aggregate of objects that is returned by the factory.
    Be careful not to implement new functionality; the current test should still fail.
</ol>
<h3>Gilded Mall Specs</h3>
  <p>Hello and welcome to team Gilded Mall. As you know, we are a small shopping mall opening in a prime location in
    a prominent city. We will house a growing number of stores, each of which will sell only the finest goods
    and services. We will provide stock management software to all our tenants, catering to their common&mdash;and
    not so common&mdash;requirements.</p>
  <ol>
  <li>All tenants want to record item name and price for all their stock. The stock list must update daily,
    applying to the following rules.
  <li>All shops will record a sale price for each stock item.
  <li>The Gilded Dress will reduce the sale price of each item by 10% of its original sale price every week
  until it falls to 25% of original price, from which point it stays constant.
  <li>The Gilded Tin Can sells tinned food. Each can has a sell by date typically about a year from when it
  comes in. Two months before that date, the sale price will be halved. When the date passes, the can
  is unsaleable and must be removed from stock.
  <li>The Gilded Carrot sells fresh vegetables. It must always dispose of stock that it has held for 7 days,
  and will sell items at half price on the day of the deadline.
  <li>The Gilded Cheese Wheel sells excellent cheeses. It must always dispose of stock that it has held for 28
  days, and will sell items at half price in the week before the deadline.
  <li>The Gilded Cheese wants to sell a speciality “Aged Brie”. This increases in price by 20% each week
  for 28 days at which point it's price stays constant for a further 2 years.
  <li>The Gilded Armoury sells iron weapons which lose 10% of their value each year. Except for a legendary
    weapon “Sulfuras”, which they'll only ever sell for £100,000.
  <li>The Gilded Stage sells concert tickets. These increase in price by 20% each week until the date of the
  concert, on which day they are sold at half price. The following day they become valueless and are binned.
  </ol>
