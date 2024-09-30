namespace GildedRoseKata
{
    public interface IItemProcessingRules
    {
        int DailyQualityAdjustment { get; }
        bool ExpiresAfterSellIn { get; }
        bool RequiresQualityUpdate { get; }

        int GetExtraQualityAdjustmentBySellIn(int sellIn);
    }
}