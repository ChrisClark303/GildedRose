using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void Item_Quality_ShouldDegradeOverTime()
        {
            IList<Item> items = [new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 10 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(9, items[0].Quality);
        }

        [Fact]
        public void Item_Quality_ShouldDegradeByTwoAfterSellInReachesZero()
        {
            IList<Item> items = [new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 10 }];
            GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void Item_Quality_ShouldNeverDecreaseBelowZero()
        {
            IList<Item> Items = [new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 0 }];
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void Item_SellIn_ShouldDecreaseOverTime()
        {
            IList<Item> Items = [new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 10 }];
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
        }

        [Fact]
        public void ItemIsSulfuras_Quality_ShouldNotChangeOverTime()
        {
            IList<Item> Items = [new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }];
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void ItemIsAgedBrie_Quality_ShouldIncreaseOverTime()
        {
            IList<Item> Items = [new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 }];
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void ItemIsBackstagePass_Quality_ShouldIncreaseOverTime()
        {
            IList<Item> Items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 }];
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void ItemIsBackstagePass_Quality_ShouldIncreaseByTwoSixToTenDaysFromConcert()
        {
            IList<Item> Items = [
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10 }];
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(12, Items[0].Quality);
            Assert.Equal(12, Items[1].Quality);
        }

        [Fact]
        public void ItemIsBackstagePass_Quality_ShouldIncreaseByThreeFiveDaysFromConcert()
        {
            IList<Item> Items = [
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 10 }];
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(13, Items[0].Quality);
            Assert.Equal(13, Items[1].Quality);
        }

        [Fact]
        public void ItemIsBackstagePass_Quality_ShouldReduceToZeroAfterConcert()
        {
            IList<Item> Items = [
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }];
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void Item_Quality_ShouldNeverIncreaseOverFifty()
        {
            IList<Item> Items = [
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 }
            ];
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
            Assert.Equal(50, Items[1].Quality);
        }
    }
}
