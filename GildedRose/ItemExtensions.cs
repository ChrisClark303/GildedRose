using System;
using System.Linq;

namespace GildedRoseKata
{
    public static class ItemExtensions
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        public static void IncrementQualityIfNotAtMax(this Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
            }
        }

        public static void AmendQualityByAmount(this Item item, int amount)
        {
            int newQualityAmount = item.Quality + amount;
            item.Quality = Math.Clamp(newQualityAmount, MinQuality, MaxQuality);
        }

        public static void SetQualityToMinimum(this Item item)
        {
            item.Quality = MinQuality;
        }
    }
}