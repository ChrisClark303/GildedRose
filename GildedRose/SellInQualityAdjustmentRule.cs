namespace GildedRoseKata
{
    public class SellInQualityAdjustmentRule(int sellInThreshold, int qualityAdjustment)
    {
        public int SellInThreshold { get; } = sellInThreshold;
        public int QualityAdjustment { get; } = qualityAdjustment;
    }
}
