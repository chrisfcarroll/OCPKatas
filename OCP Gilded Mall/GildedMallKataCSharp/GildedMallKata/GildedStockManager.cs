using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildMallKata
{

    public class GildedStockManager 
    {
        public GildedStockManager()
        {
            StockList = new List<StockItem> ();
        }

        public List<StockItem> StockList { get; private set; }
    }

    public class GildedStockManagerV2 : GildedStockManager
    {
        public string Name { get; private set;}

        readonly DateTime startDate = DateTime.Today;
        int age;

        public GildedStockManagerV2( string name )
        {
            Name = name;
        }

        new IEnumerable<StockItemV2> StockList { get { return base.StockList.Cast<StockItemV2>(); } }

        public void EndOfDay()
        {
            age+=1;
            foreach(var item in StockList)
            {
                if(startDate.AddDays(age) == item.ArrivedInStock.AddDays(71) )
                {
                    item.Price *= 0.75m;
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

}