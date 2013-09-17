using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildMallKata
{
    public class GildedStockManagerFactory
    {
        public static GildedStockManager Create()
        {
            return new GildedStockManager ();
        }

        public static GildedStockManager CreateGildedDress()
        {
            throw new NotImplementedException();
        }
    }
}
