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

            var provider = new ItemProcessingRuleProvider(
                ItemDataProvider.GetItemRules(),
                new ItemProcessingRules(-1)
            );

            IList<Item> items = ItemDataProvider.GetItemsInStock();

            DisplayItemState(items, 0); //display initial item state
            
            var app = new GildedRose(items, provider);
            for (var i = 1; i <= numOfDays; i++)
            {
                app.UpdateQuality();
                DisplayItemState(items, i);
            }
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
