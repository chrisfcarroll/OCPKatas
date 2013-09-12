function gildedDressesTestCase1(){ return [ {name: "A dress", price: 10.00} ]; }

describe("The Gilded Mall - Specifications.", function () {

  describe("All tenants", function () {

    theGildedDress.stockList = gildedDressesTestCase1();

    for (var key in allShops) {
      var thisShop = allShops[key];

      describe("want to record stock", function () {

        it("should record item name and price for all their stock", function () {
          thisShop.stockList.forEach(function (item) {
            expect(item.name).toBeDefined();
            expect(item.price).toBeDefined();
          });
        });
      });

    }
  });

  describe("The Gilded Dress", function(){
    it("should",function(){ });
  });

});
