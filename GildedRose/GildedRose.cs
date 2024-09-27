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
                if (item.Name == ItemNames.Sulfuras) continue;

                //nested ifs!
                if (item.Name != ItemNames.AgedBrie && item.Name != ItemNames.BackstagePass)
                {
                    DecrementQualityIfNotAtMin(item);
                }
                else
                {
                    if (item.Quality < MaxQuality)
                    {
                        IncrementQualityIfNotAtMax(item);

                        if (item.Name == ItemNames.BackstagePass)
                        {
                            if (item.SellIn < 11) //magic number
                            {
                                IncrementQualityIfNotAtMax(item);
                            }

                            if (item.SellIn < 6) //magic number
                            {
                                IncrementQualityIfNotAtMax(item);
                            }
                        }
                    }
                }

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    HandleItemPastSellByDate(item);
                }
            }
        }

        private void HandleItemPastSellByDate(Item item)
        {
            if (item.Name == ItemNames.Sulfuras) return;

            if (item.Name == ItemNames.AgedBrie)
            {
                IncrementQualityIfNotAtMax(item);
                return;
            }

            if (item.Name == ItemNames.BackstagePass)
            {
                item.Quality = MinQuality;
                return;
            }

            DecrementQualityIfNotAtMin(item);
        }

        private static void DecrementQualityIfNotAtMin(Item item)
        {
            if (item.Quality > MinQuality)
            {
                item.Quality--;
            }
        }

        private void IncrementQualityIfNotAtMax(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
            }
        }
    }
}