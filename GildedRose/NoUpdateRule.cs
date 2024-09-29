namespace GildedRoseKata
{
    public class NoUpdateRule : IItemQualityProcessingRule
    {
        public int DailyQualityAdjustment => 0;

        public bool ExpiresAfterSellIn => false;

        public bool RequiresQualityUpdate => false;

        public int GetExtraQualityAdjustmentBySellIn(int sellIn) => 0;
    }
}
