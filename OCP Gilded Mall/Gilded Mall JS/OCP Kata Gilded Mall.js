var gildedStockList= function(){

  var me= {
    stockList : []
  };

  return me;
}();

var GildedShopFactory= function(shopName){
  return  Object.create(gildedStockList,{shopName:{value:shopName}});
};

var theGildedDress = GildedShopFactory("Gilded Dress");

var allShops= {
  gildedDress : theGildedDress
};
