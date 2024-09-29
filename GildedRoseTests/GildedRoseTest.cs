using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using Xunit.Abstractions;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQuality_StandardItem_QualityShouldDegradeOverTime()
        {
            IList<Item> items = [new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 10 }];
            var rules = new Dictionary<string, IItemProcessingRules>();

            GildedRose app = new(items, new ItemProcessingRuleProvider(rules, new ItemProcessingRule(-1)));
            app.UpdateQuality();

            Assert.Equal(9, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_StandardItem_ShouldDegradeByTwoAfterSellInReachesZero()
        {
            IList<Item> items = [new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 10 }];
            var rules = new Dictionary<string, IItemProcessingRules>();

            GildedRose app = new(items, new ItemProcessingRuleProvider(rules, new ItemProcessingRule(-1)));
            app.UpdateQuality();

            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void Item_Quality_ShouldNeverDecreaseBelowZero()
        {
            IList<Item> items = [new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 0 }];
            var rules = new Dictionary<string, IItemProcessingRules>();

            GildedRose app = new(items, new ItemProcessingRuleProvider(rules, new ItemProcessingRule(-1)));
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void Item_SellIn_ShouldDecreaseOverTime()
        {
            IList<Item> items = [new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 10 }];
            var rules = new Dictionary<string, IItemProcessingRules>();

            GildedRose app = new(items, new ItemProcessingRuleProvider(rules, new ItemProcessingRule(-1)));
            app.UpdateQuality();
            Assert.Equal(9, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_ItemDoesNotRequireUpdate_QualityShouldNotChangeOverTime()
        {
            IList<Item> items = [new Item { Name = "Sulfuras", SellIn = 0, Quality = 80 }];

            var rules = new Dictionary<string, IItemProcessingRules>
            {
                {"Sulfuras", new NoUpdateRule()}
            };
  
            GildedRose app = new(items, new ItemProcessingRuleProvider(rules, new ItemProcessingRule(-1)));
            app.UpdateQuality();
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ItemHasRuleForPositiveDailyQualityAdjustment_QualityShouldIncreaseOverTime()
        {
            IList<Item> items = [new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 }];

            var rules = new Dictionary<string, IItemProcessingRules>
            {
                {"Aged Brie", new ItemProcessingRule(1)}
            };

            GildedRose app = new(items, new ItemProcessingRuleProvider(rules, new ItemProcessingRule(-1)));
            app.UpdateQuality();
            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ItemHasRuleForPositiveDailyQualityAdjustment_QualityShouldNotIncreaseOverFifty()
        {
            IList<Item> items = [new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 }];
            var rules = new Dictionary<string, IItemProcessingRules>
            {
                {"Aged Brie", new ItemProcessingRule(1)}
            };

            GildedRose app = new(items, new ItemProcessingRuleProvider(rules, new ItemProcessingRule(-1)));
            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void ItemIsBackstagePass_Quality_ShouldIncreaseByTwoSixToTenDaysFromConcert()
        {
            IList<Item> items = [
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10 }];
            var rules = new Dictionary<string, IItemProcessingRules>
            {
                {"Backstage passes to a TAFKAL80ETC concert", new ItemProcessingRule(1)}
            };

            GildedRose app = new(items, new ItemProcessingRuleProvider(rules, new ItemProcessingRule(-1)));
            app.UpdateQuality();

            Assert.Equal(12, items[0].Quality);
            Assert.Equal(12, items[1].Quality);
        }

        [Fact]
        public void ItemIsBackstagePass_Quality_ShouldIncreaseByThreeFiveDaysFromConcert()
        {
            IList<Item> items = [
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 10 }];
            var rules = new Dictionary<string, IItemProcessingRules>
            {
                {"Backstage passes to a TAFKAL80ETC concert", new ItemProcessingRule(1)}
            };

            GildedRose app = new(items, new ItemProcessingRuleProvider(rules, new ItemProcessingRule(-1)));
            app.UpdateQuality();
            Assert.Equal(13, items[0].Quality);
            Assert.Equal(13, items[1].Quality);
        }

        [Fact]
        public void ItemIsBackstagePass_Quality_ShouldReduceToZeroAfterConcert()
        {
            IList<Item> items = [
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }];
            var rules = new Dictionary<string, IItemProcessingRules>();

            GildedRose app = new(items, new ItemProcessingRuleProvider(rules, new ItemProcessingRule(-1)));
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }
    }
}
