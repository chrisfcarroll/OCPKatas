using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildMallKata
{
    /// <summary>
    /// Backwards compatibility interface freezes the interface 'shipped' after Test 1.
    /// </summary>
    public interface IStockManager1
    {
        List<StockItem> StockList { get; }
    }
    
    /// <summary>
    /// The interface shipped for Test 2 & 3
    /// </summary>
    public interface IStockManager2 : IStockManager1
    {
        new List<StockItemV2> StockList { get; }
        DateTime StartDate { get; }
        int Age { get; }
        void EndOfDay();
        void EndOfDay( int dayPassed );
    }

    public class GildedStockManager : IStockManager1, IStockManager2
    {
        List<StockItem> IStockManager1.StockList 
                    { get { return StockList.Select(i=> i as StockItem).ToList() ; } }

        public List<StockItemV2> StockList { get; private set; }

        public string Name { get; private set;}

        public DateTime StartDate { get ; private set;}

        public int Age { get; protected set;}

        protected List<AgingRule> AgingRules;

        readonly DateTime startDate = DateTime.Today;

        public GildedStockManager(ShopConfiguration configuration)
        {
            StartDate = DateTime.Today;
            StockList = new List<StockItemV2> ();
            Name = configuration.Name;
            AgingRules = configuration.AgingRules;
        }

        public void EndOfDay()
        {
            Age+=1;
            for(var i=0; i< StockList.Count; i++)
            {
                foreach(var rule in AgingRules)
                {
                    rule(this, StockList[i]);
                }
            }
        }

        public void EndOfDay(int daysPassed)
        {
            for(int i=1; i<=daysPassed; i++){ EndOfDay(); }
        }
    }

    public class StockItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class StockItemV2 : StockItem
    {
        public StockItemV2()
        {
            ArrivedInStock = DateTime.Today;
        }
        public DateTime ArrivedInStock {get; set;}
    }

    public class StockItemWithSellBy : StockItemV2
    {
        public DateTime SellBy {get; set;}
    }
}