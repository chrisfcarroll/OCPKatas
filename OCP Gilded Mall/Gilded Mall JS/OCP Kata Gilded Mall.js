var gildedShop= function(){

  var me= {
    stockList : [],
    ageStock : function(days){}
  };

  return me;
}();

var allShops= {};

var GildedShopFactory= function(shopName){
  allShops[shopName]= Object.create(gildedShop,{shopName:{value:shopName}});
  return allShops[shopName];
};

var theGildedDress = GildedShopFactory("Gilded Dress");

