using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string numOfDaysArg = args.FirstOrDefault();
            int numOfDays = int.Parse(numOfDaysArg ?? "0");

            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = ItemNames.DexterityVest, SellIn = 10, Quality = 20},
                new Item {Name = ItemNames.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = ItemNames.MongooseElixir, SellIn = 5, Quality = 7},
                new Item {Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = ItemNames.Sulfuras, SellIn = -1, Quality = 80},
                new Item
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = ItemNames.ConjuredManaCake, SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            DisplayItemState(Items, 0); //display initial item state
            for (var i = 1; i <= numOfDays; i++)
            {
                app.UpdateQuality();
                DisplayItemState(Items, i);
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
