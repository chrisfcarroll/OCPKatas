package org.softwarecraftsmanship.gilded.mall;

import org.junit.Before;
import org.junit.Test;

import static org.assertj.core.api.Assertions.*;

public class GildedMallTests {

    private GildedStockManager shop;

    @Before
    public void setUp() {
        shop = GildedStockManagerFactory.create();
    }

    @Test
    public void allTenantsWantToRecordItemNameAndPrice() {
        //http://joel-costigliola.github.io/assertj/

        assertThat(shop.stockList())
                .extracting(GildedStockManager.StockItem::getName)
                .isNotNull();

        assertThat(shop.stockList())
                .extracting(GildedStockManager.StockItem::getPrice)
                .isNotNull();
    }
}
