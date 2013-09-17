using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildMallKata;
using NUnit.Framework;
using TestBase.Shoulds;

namespace ClassLibrary1
{
    [TestFixture]
    public class GildedMallTests
    {
        GildedStockManager shop;

        [SetUp]
        public void SetUp()
        {
            shop = new GildedStockManager ();
        }

        [Test]
        public void AllTenantsWantToRecordItemNameAndPrice()
        {
            shop.StockList.ShouldAllSatisfy (i => i.Name, Is.Not.Null );
            shop.StockList.ShouldAllSatisfy (i => i.Price, Is.Not.Null );
        }
    }
}