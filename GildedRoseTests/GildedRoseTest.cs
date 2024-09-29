using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQuality_DefaultItem_QualityShouldDegradeOverTime()
        {
            IList<Item> items = [new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 10 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(9, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_DefaultItem_QualityShouldDegradeByTwoAfterSellInReachesZero()
        {
            IList<Item> items = [new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 10 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_QualityShouldNeverDecreaseBelowZero()
        {
            IList<Item> items = [new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 0 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_SellInShouldDecreaseOverTime()
        {
            IList<Item> items = [new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 10 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(9, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_ItemIsSulfuras_QualityShouldNotChangeOverTime()
        {
            IList<Item> items = [new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ItemIsAgedBrie_QualityShouldIncreaseOverTime()
        {
            IList<Item> items = [new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ItemIsBackstagePass_QualityShouldIncreaseOverTime()
        {
            IList<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ItemIsBackstagePass_QualityShouldIncreaseByTwoSixToTenDaysFromConcert()
        {
            IList<Item> items = [
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(12, items[0].Quality);
            Assert.Equal(12, items[1].Quality);
        }

        [Fact]
        public void UpdateQuality_ItemIsBackstagePass_QualityShouldIncreaseByThreeFiveDaysFromConcert()
        {
            IList<Item> items = [
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 10 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(13, items[0].Quality);
            Assert.Equal(13, items[1].Quality);
        }

        [Fact]
        public void UpdateQuality_ItemIsBackstagePass_QualityShouldReduceToZeroAfterConcert()
        {
            IList<Item> items = [
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_QualityShouldNeverIncreaseOverFifty()
        {
            IList<Item> items = [
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 }
            ];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
            Assert.Equal(50, items[1].Quality);
        }
    }
}
