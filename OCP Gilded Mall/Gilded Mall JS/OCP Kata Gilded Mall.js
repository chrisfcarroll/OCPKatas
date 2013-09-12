var gildedStockList= function(){

  var me= {
    stockList : [],
    age : function(){}
  };

  return me;
}();

var GildedShopFactory= function(shopName){
  return  Object.create(gildedStockList,{shopName:{value:shopName}});
};

var GildedDressFactory= function(){
  var me= GildedShopFactory("Gilded Dress");
  me.age= function(days){
    me.stockList.forEach(function(item){
      var weeksPassed= Math.round( (item.daysInStock+days) /7) ;
      if(weeksPassed<=7){
        item.price = item.originalPrice * (1 - 0.10 * weeksPassed);
      }else{
        item.price = item.originalPrice * 0.25;
      }
      item.daysInStock+=days;
    });
  }
  return me;
};

var GildedTinFactory= function(){
  var me= GildedShopFactory("The Tin Can");
  me.age=function(days){
    me.stockList.forEach(function(item){
      if(item.daysToSellBy>61){
        item.price= item.originalPrice * 0.5;
      }
      item.daysInStock +=days;
      item.daysToSellBy -=days;
    });
  };
  return me;
}

var theGildedDress = GildedDressFactory();
var theGildedTinCan = GildedTinFactory();

var allShops= {
  gildedDress  : theGildedDress,
  gildedTinCan : theGildedTinCan
};
