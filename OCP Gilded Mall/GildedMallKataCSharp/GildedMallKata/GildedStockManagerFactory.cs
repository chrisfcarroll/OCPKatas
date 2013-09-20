using System;
using System.Collections.Generic;

namespace GildMallKata
{
    public class GildedStockManagerFactory
    {
        public static GildedStockManager Create()
        {
            return new GildedStockManager(new ShopConfiguration{Name="Unname",AgingRules= new List<AgingRule>()});
        }

        public static IStockManager2 CreateGildedDress()
        {
            return new GildedStockManager(GildedDressConfiguration.Configuration);
        }

        public static IStockManager2 CreateGildedTinCan()
        {
            throw new NotImplementedException();
        }
    }

    public class ShopConfiguration
    {
        public string Name { get; set;}
        public List<AgingRule> AgingRules { get; set;}
    }

    public delegate void AgingRule(IStockManager2 stockManager, StockItemV2 stockItem);

    public static class GildedDressConfiguration
    {
        public static ShopConfiguration Configuration = new ShopConfiguration
        {
            Name="Gilded Dress",
            AgingRules= new List<AgingRule>
            {
                (shop,item) =>
                {
                    if (shop.StartDate.AddDays( shop.Age ) == item.ArrivedInStock.AddDays( 71 )) 
                    { item.Price *= 0.75m; }
                }
            }
        };
    }

    public static class GildedTinCanConfiguration
    {
        public static ShopConfiguration Configuration;

        static GildedTinCanConfiguration()
        {
            Configuration = new ShopConfiguration
            {
                Name="Gilded Tin Can",
                AgingRules= new List<AgingRule> { DisposeOfCansPastSellBy }
            };
        }
        static AgingRule DisposeOfCansPastSellBy= (shop,item) => 
        {
            if( item is StockItemWithSellBy && shop.StartDate.AddDays(shop.Age) > ((StockItemWithSellBy)item).SellBy)
            {
                shop.StockList.Remove(item);
            }
        };
    }


}
