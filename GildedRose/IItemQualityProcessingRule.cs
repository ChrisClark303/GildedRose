namespace GildedRoseKata
{
    public interface IItemQualityProcessingRule
    {
        int DailyQualityAdjustment { get; }
        bool ExpiresAfterSellIn { get; }
        bool RequiresQualityUpdate { get; }

        int GetExtraQualityAdjustmentBySellIn(int sellIn);
    }
}