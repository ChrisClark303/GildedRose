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

            IList<Item> items = GetItemsInStock();
            DisplayItemState(items, 0); //display initial item state
            
            var app = new GildedRose(items);
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
