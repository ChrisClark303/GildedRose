using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items; //no accessor, name not correct for a field.
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (!item.RequiresQualityUpdates()) continue;

                UpdateItemQuality(item);

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    HandleItemPastSellIn(item);
                }
            }
        }

        private static void UpdateItemQuality(Item item)
        {
            if (item.QualityIncreasesWithAge())
            {
                if (item.IsLessThanMaxQuality())
                {
                    item.IncrementQualityIfNotAtMax();

                    if (item.Name == ItemNames.BackstagePass)
                    {
                        if (item.SellIn < 11) //magic number
                        {
                            item.IncrementQualityIfNotAtMax();
                        }

                        if (item.SellIn < 6) //magic number
                        {
                            item.IncrementQualityIfNotAtMax();
                        }
                    }
                }

                return;
            }

            item.DecrementQualityIfNotAtMin();
        }

        private static void HandleItemPastSellIn(Item item)
        {
            if (item.ExpiresAfterSellIn())
            {
                item.SetQualityToMinimum();
                return;
            }

            if (item.QualityIncreasesWithAge())
            {
                item.IncrementQualityIfNotAtMax();
                return;
            }

            item.DecrementQualityIfNotAtMin();
        }
    }
}