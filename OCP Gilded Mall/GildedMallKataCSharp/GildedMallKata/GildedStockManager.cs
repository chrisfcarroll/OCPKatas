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

    public class StockItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}