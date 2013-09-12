function gildedDressesTestCase1(){
  return [ {name: "A dress", daysInStock:0, price: 10.00, originalPrice:10.00} ];
};

function gildedTinCanTestCase1(){
  return [ {name: "Tin of beans", daysInStock:0, price: 10.00, originalPrice:10.00, daysToSellBy:365} ];
}

describe("The Gilded Mall - Specifications.", function () {

  describe("All tenants", function () {

    theGildedDress.stockList = gildedDressesTestCase1();
    theGildedTinCan.stockList= gildedTinCanTestCase1();

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

    beforeEach(function(){
      theGildedDress.stockList = gildedDressesTestCase1();
    });

    describe("For every week that passes",function(){

      var originalPrices= theGildedDress.stockList.map(function(i){return _.clone(i);});

      beforeEach(function(){
        theGildedDress.age(7);
      });

      it("should reduce the sale price of each item by 10% of its original sale price after 1 week", function(){
        for(var i=0; i< theGildedDress.stockList.length; i+=1){
          expect(theGildedDress.stockList[i].price).toBe(originalPrices[i].price * 0.9);
        }
      });

      it("should reduce the sale price of each item by 20% of its original sale price after 2 weeks", function(){
        theGildedDress.age(7);
        for(var i=0; i< theGildedDress.stockList.length; i+=1){
          expect(theGildedDress.stockList[i].price).toBe(originalPrices[i].price * 0.8);
        }
      });

      it("So long as the price hasn't fallen to 25% of original price, after which it stays flat",function(){
        theGildedDress.age(7*8);
        for(var i=0; i< theGildedDress.stockList.length; i+=1){
          expect(theGildedDress.stockList[i].price).toBe(originalPrices[i].price * 0.25);
        }
      })

    });

  });

  describe("The Gilded TinCan", function(){

    beforeEach(function(){
      theGildedTinCan.stockList= gildedTinCanTestCase1();
    });

    describe("When an item is more than 2 months from its sellby date",function(){

      var originalPrices= theGildedTinCan.stockList.map(function(i){return _.clone(i);});

      it("When an item is more than 2 months from its sell-by date it should sell for its original value", function(){
        for(var i=0; i< theGildedTinCan.stockList.length; i+=1){
          expect(theGildedTinCan.stockList[i].price).toBe(originalPrices[i].price);
        }
      });

      it("When an item is less than 2 months from its sell-by date it should sell at half price", function(){
        theGildedTinCan.age(360);
        for(var i=0; i< theGildedTinCan.stockList.length; i+=1){
          expect(theGildedTinCan.stockList[i].price).toBe(originalPrices[i].price * 0.5);
        }
      });

    });

  });

});
