using System.Collections.Generic;

namespace GildedRoseKata
{
    public static class ItemDataProvider
    {
        public static IDictionary<string, IItemProcessingRules> GetItemRules()
        {
            return new Dictionary<string, IItemProcessingRules>
            {
                {ItemNames.Sulfuras, new NoUpdateRule()},
                {ItemNames.ConjuredManaCake, new ItemProcessingRules(-2) },
                {ItemNames.AgedBrie, new ItemProcessingRules(1) },
                {ItemNames.BackstagePass, new ItemProcessingRules(1,
                expiresAfterSellIn: true,
                sellInQualityAdjustmentRules: [
                    new SellInQualityAdjustmentRule(10, 1),
                    new SellInQualityAdjustmentRule(5, 1)
                    ]) }
            };
        }

        public static IList<Item> GetItemsInStock()
        {
            return new List<Item>{
                new() {Name = ItemNames.DexterityVest, SellIn = 10, Quality = 20},
                new() {Name = ItemNames.AgedBrie, SellIn = 2, Quality = 0},
                new() {Name = ItemNames.MongooseElixir, SellIn = 5, Quality = 7},
                new() {Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80},
                new() {Name = ItemNames.Sulfuras, SellIn = -1, Quality = 80},
                new() {Name = ItemNames.BackstagePass, SellIn = 15, Quality = 20},
                new() {Name = ItemNames.BackstagePass, SellIn = 10, Quality = 49},
                new() {Name = ItemNames.BackstagePass, SellIn = 5, Quality = 49},
                new() {Name = ItemNames.ConjuredManaCake, SellIn = 3, Quality = 6}
            };
        }
    }
}
