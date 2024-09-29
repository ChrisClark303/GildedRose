using System;
using System.Linq;

namespace GildedRoseKata
{
    public static class ItemExtensions
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        private static readonly int[] ItemSellInThresholds = [10, 5];

        public static void DegradeQualityUntilMin(this Item item)
        {
            int qualityDegradation = item.Name == ItemNames.ConjuredManaCake
                 ? 2
                 : 1;

            item.Quality = Math.Max(item.Quality - qualityDegradation, 0);
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

        public static void ApplySellInDependentQualityUpdate(this Item item)
        {
            if (item.Name == ItemNames.BackstagePass)
            {
                int qualityUpdate = ItemSellInThresholds.Count(t => item.SellIn <= t);
                item.Quality = Math.Clamp(item.Quality + qualityUpdate, MinQuality, MaxQuality);
            }
        }
    }
}