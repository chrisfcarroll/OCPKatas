var gs = GildedRoseFactory();

function cloneArray(array) {
  var cloned = [];
  for (var i = 0; i < array.length; i += 1) {
    cloned.push(_.clone(array[i]));
  }
  return cloned;
}

function testCase_1Item_10_20(){
  return [
    {name: "Something", sellIn: 10, quality: 20}
  ];
}

describe("The Gilded Rose - Specifications.", function () {

  describe("Given something is in stock", function () {

    gs.stockList = testCase_1Item_10_20();

    it("the stockList should be a non-empty list.", function () {
      expect(gs.stockList.length).toBeGreaterThan(0);
    });

    it("All items have a SellIn value which denotes the number of days we have to sell the item.", function () {
      gs.stockList.forEach(function (item) {
        expect(item.sellIn).toBeDefined();
      });
    });

    it("All items have a Quality value which denotes how valuable the item is.", function () {
      gs.stockList.forEach(function (item) {
        expect(item.quality).toBeDefined();
      });
    });
  })

  describe("At the end of each day our system lowers both values for every item.", function () {

    var initialValues;

    beforeEach(function(){
      gs.stockList= testCase_1Item_10_20();
      initialValues = cloneArray(gs.stockList);
    });

    it("After aging, each item in stocklist should have sellIn and quality reduced by 1", function () {
      gs.age();
      for (var i = 0; i < gs.stockList.length; i += 1) {
        expect(gs.stockList[i].sellIn ).toBe(initialValues[i].sellIn  - 1);
        expect(gs.stockList[i].quality).toBe(initialValues[i].quality - 1);
      }
    });

    it("But once the sell by date has passed, Quality degrades twice as fast", function(){
      gs.ageN(11);
      for (var i = 0; i < gs.stockList.length; i += 1) {
        expect(gs.stockList[i].sellIn ).toBe( - 1);
        expect(gs.stockList[i].quality).toBe(initialValues[i].quality - 12);
      }

    });

    it("The Quality of an item is never negative", function(){

    });

  });

});