using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string numOfDaysArg = args.FirstOrDefault();
            int numOfDays = int.Parse(numOfDaysArg ?? "0");

            Console.WriteLine("OMGHAI!");

            IDictionary<string,IItemProcessingRules> itemRules = GetItemRules();
            ItemProcessingRule defaultRules = new ItemProcessingRule(-1);

            var provider = new ItemProcessingRuleProvider(itemRules, defaultRules);

            IList<Item> items = GetItemsInStock();
            DisplayItemState(items, 0); //display initial item state
            
            var app = new GildedRose(items, provider);
            for (var i = 1; i <= numOfDays; i++)
            {
                app.UpdateQuality();
                DisplayItemState(items, i);
            }
        }

        private static IList<Item> GetItemsInStock()
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
				// this conjured item does not work properly yet
				new() {Name = ItemNames.ConjuredManaCake, SellIn = 3, Quality = 6}
            };
        }

        private static IDictionary<string, IItemProcessingRules> GetItemRules()
        {
            return new Dictionary<string, IItemProcessingRules>
            {
                {ItemNames.Sulfuras, new NoUpdateRule()},
                {ItemNames.ConjuredManaCake, new ItemProcessingRule(-2) },
                {ItemNames.AgedBrie, new ItemProcessingRule(1) },
                {ItemNames.BackstagePass, new ItemProcessingRule(1, sellInQualityAdjustmentRules: [
                    new SellInQualityAdjustmentRule(10, 1),
                    new SellInQualityAdjustmentRule(5, 1)
                    ]) }
            };
        }

        private static void DisplayItemState(IList<Item> items, int day)
        {
            Console.WriteLine("-------- day " + day + " --------");
            Console.WriteLine("name, sellIn, quality");
            foreach (Item item in items)
            {
                System.Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
            }
            Console.WriteLine("");
        }
    }
}
