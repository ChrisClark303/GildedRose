using System;
using System.Linq;

namespace GildedRoseKata
{
    public static class ItemExtensions
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        private static readonly int[] ItemSellInThresholds = [10, 5];

        public static void DecrementQualityIfNotAtMin(this Item item)
        {
            if (item.Quality > MinQuality)
            {
                item.Quality--;
            }
        }

        public static void IncrementQualityIfNotAtMax(this Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
            }
        }

        public static void SetQualityToMinimum(this Item item)
        {
            item.Quality = MinQuality;
        }

        public static bool QualityIncreasesWithAge(this Item item)
        {
            return (item.Name == ItemNames.AgedBrie || item.Name == ItemNames.BackstagePass);
        }

        public static bool RequiresQualityUpdates(this Item item)
        {
            return item.Name != ItemNames.Sulfuras;
        }

        public static bool ExpiresAfterSellIn(this Item item)
        {
            return item.Name == ItemNames.BackstagePass;
        }

        public static bool HasSellInDependentQualityUpdates(this Item item)
        {
            return item.Name == ItemNames.BackstagePass;
        }

        public static void ApplySellInDependentQualityUpdate(this Item item)
        {
            if (item.HasSellInDependentQualityUpdates())
            {
                int qualityUpdate = ItemSellInThresholds.Where(t => item.SellIn <= t)
                    .Count();
                item.Quality = Math.Clamp(item.Quality + qualityUpdate, MinQuality, MaxQuality);
            }
        }
    }
}