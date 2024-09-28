namespace GildedRoseKata
{
    public static class ItemExtensions
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

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

        public static bool IsLessThanMaxQuality(this Item item)
        {
            return item.Quality < MaxQuality;
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
    }
}