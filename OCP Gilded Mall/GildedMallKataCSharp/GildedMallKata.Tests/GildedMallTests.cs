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
        IStockManager1 shop;

        [SetUp]
        public void SetUp()
        {
            shop = GildedStockManagerFactory.CreateGildedDress();
        }

        [Test]
        public void AllTenantsWantToRecordItemNameAndPrice()
        {
            shop.StockList.ShouldAllSatisfy (i => i.Name, Is.Not.Null );
            shop.StockList.ShouldAllSatisfy (i => i.Price, Is.Not.Null );
        }
    }

    [TestFixture]
    public class GildedDressTests
    {
        IStockManager2 classUnderTest;
        List<StockItemV2> testData= new List<StockItemV2>{
            new StockItemV2{Name="Red Dress",  Price=10},
            new StockItemV2{Name="Blue Dress", Price=15}
        };

        [SetUp]
        public void SetupWithStock()
        {
            classUnderTest = GildedStockManagerFactory.CreateGildedDress();
            classUnderTest.StockList.AddRange(testData);
        }
        
        [Test]
        public void ShouldKeepPriceLevelFor10Weeks()
        {
            //A
            var originalPrices = classUnderTest.StockList.Select (i => i.GetHashCode()).ToList ();

            for(int i=1; i<=70; i++){
                //A
                classUnderTest.EndOfDay();
                //A
                classUnderTest.StockList.Select(it=>it.GetHashCode()).Except(originalPrices).ShouldBeEmpty();
            }
        }

        [Test]
        public void ShouldReduceThePriceOfEachItemBy25pcAfterItHasBeenInStockFor10Weeks()
        {
            //A
            var originalPrices = classUnderTest.StockList
                                               .Select (i => new StockItem { Name=i.Name, Price= i.Price }).ToList ();
            //A
            classUnderTest.EndOfDay(71);
            //A
            foreach(var originalItem in originalPrices)
            {
                var itemNow = classUnderTest.StockList.First (i => i.Name == originalItem.Name);
                itemNow.Price.ShouldEqual(originalItem.Price * 0.75m);
            }

        }
    }

    [TestFixture]
    public class GildedTinCanTests
    {
        IStockManager2 classUnderTest;
        List<StockItemV2> testData= new List<StockItemV2>{
            new StockItemWithSellBy{Name="Beans", Price=10, SellBy=DateTime.Now.AddDays(365)},
            new StockItemWithSellBy{Name="Peas", Price=15, SellBy=DateTime.Now.AddDays(370)}
        };

        [SetUp]
        public void SetupWithStock()
        {
            classUnderTest = GildedStockManagerFactory.CreateGildedTinCan();
            classUnderTest.StockList.AddRange(testData);
        }

        [Test]
        public void ShouldKeepStockUntilSellBy()
        {
            classUnderTest.EndOfDay(365);
            classUnderTest.StockList.Count.ShouldEqual( 2 );
        }

        [Test]
        public void ShouldDisposeOfStockAtSellBy()
        {
            classUnderTest.EndOfDay(366);
            classUnderTest.StockList.Count.ShouldEqual( 1 );
            classUnderTest.EndOfDay(5);
            classUnderTest.StockList.Count.ShouldEqual(0);
        }


    }
}