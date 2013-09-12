var gildedRoseStockList= function(){

  var me= {
    stockList : []
  };

  return me;
}();

var gildedRoseAge1Day= function(gr){
  gr.age= function age(){
    gr.stockList.forEach(function(item){
      item.sellIn -=1;
      item.quality -=1;
    })
  };
  return gr;
}

//Although 'unmodified' this function becomes redundant once gildedRoseAgeAfterSellBy is defined ...
var gildedRoseAgeNDays= function(gr){
  gr.ageN= function ageN(days){
    gr.stockList.forEach(function(item){
      item.sellIn -=days;
      item.quality -=days;
    })
  };
  return gr;
}

var gildedRoseAgeAfterSellBy= function(gr){

  gr.ageItem= function(item){
    item.sellIn--;
    var qualityLoss= item.sellIn<0 ? 2 : 1;
    item.quality -= qualityLoss;
  };

  gr.ageN= function ageN(days){
    for(var i=1; i<=days; i+=1){
      gr.stockList.forEach( gr.ageItem );
    }
  };
  return gr;
}



var GildedRoseFactory= function(){
  return gildedRoseAgeAfterSellBy(
         gildedRoseAge1Day(
          Object.create(gildedRoseStockList)
         ));
};