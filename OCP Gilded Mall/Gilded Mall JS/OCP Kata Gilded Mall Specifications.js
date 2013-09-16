describe("The Gilded Mall - Specifications.", function () {

  describe("All tenants", function () {

    describe("want to record stock", function () {

      for (var key in allShops) {
        var thisShop = allShops[key];

        // Hint: The first test will pass as soon as you give it some test data with the appropriate properties defined.

        it(key + " should record item name and price for all their stock", function () {
          thisShop.stockList.forEach(function (item) {
            expect(item.name).toBeDefined();
            expect(item.price).toBeDefined();
          });
        });
      }
    });

  });
});
