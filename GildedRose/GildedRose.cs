using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        IList<Item> Items; //no accessor, name not correct for a field.
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                //nested ifs!
                if (item.Name != ItemNames.AgedBrie && item.Name != ItemNames.BackstagePass)
                {
                    if (item.Quality > MinQuality && item.Name != ItemNames.Sulfuras)
                    {
                        item.Quality--;
                    }
                }
                else
                {
                    if (item.Quality < MaxQuality)
                    {
                        item.Quality++;

                        if (item.Name == ItemNames.BackstagePass)
                        {
                            if (item.SellIn < 11) //magic number
                            {
                                if (item.Quality < MaxQuality)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < 6) //magic number
                            {
                                if (item.Quality < MaxQuality)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (item.Name != ItemNames.Sulfuras)
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    HandleItemPastSellByDate(item);
                }
            }
        }

        private void HandleItemPastSellByDate(Item item)
        {
            if (item.Name != ItemNames.AgedBrie)
            {
                if (item.Name != ItemNames.BackstagePass)
                {
                    if (item.Quality > MinQuality && item.Name != ItemNames.Sulfuras)
                    {
                        item.Quality--;
                    }
                }
                else
                {
                    item.Quality = MinQuality;
                }
            }
            else
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality++;
                }
            }
        }
    }
}