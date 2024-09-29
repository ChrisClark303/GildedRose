using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class ItemProcessingRuleTests
    {
        [Fact]
        public void NoUpdateRule_RequiresQualityUpdate_SetToFalse()
        {
            var rule = new NoUpdateRule();
            Assert.False(rule.RequiresQualityUpdate);
        }

        [Fact]
        public void ItemProcessingRule_RequiresQualityUpdate_SetToTrue()
        {
            var rule = new ItemProcessingRule(-1);
            Assert.True(rule.RequiresQualityUpdate);
        }

        [Fact]
        public void ItemProcessingRule_ExpiresAfterSellIn_SetToFalse()
        {
            var rule = new ItemProcessingRule(-1);
            Assert.False(rule.ExpiresAfterSellIn);
        }

        [Fact]
        public void GetExtraQualityAdjustmentBySellIn_SingleSellInThreshold_ItemInsideThreshold_ReturnsCorrectQualityAdjustment()
        {
            var rule = new ItemProcessingRule(-1, sellInQualityAdjustmentRules: new SellInQualityAdjustmentRule() { SellInThreshold = 10, QualityAdjustment = 2 });
            int extraQualityAdjustment = rule.GetExtraQualityAdjustmentBySellIn(5);

            Assert.Equal(2, extraQualityAdjustment);
        }


        [Fact]
        public void GetExtraQualityAdjustmentBySellIn_SingleSellInThreshold_ItemOutsideThreshold_ReturnsCorrectQualityAdjustment()
        {
            var rule = new ItemProcessingRule(-1, sellInQualityAdjustmentRules: new SellInQualityAdjustmentRule() { SellInThreshold = 10, QualityAdjustment = 2 });
            int extraQualityAdjustment = rule.GetExtraQualityAdjustmentBySellIn(11);

            Assert.Equal(0, extraQualityAdjustment);
        }

        [Fact]
        public void GetExtraQualityAdjustmentBySellIn_DoubleSellInThreshold_ItemInsideInnerThreshold_ReturnsSumQualityAdjustment()
        {
            var rule = new ItemProcessingRule(-1, sellInQualityAdjustmentRules: [
                new SellInQualityAdjustmentRule() { SellInThreshold = 10, QualityAdjustment = 1 },
                new SellInQualityAdjustmentRule() { SellInThreshold = 5, QualityAdjustment = 1 }]);
            int extraQualityAdjustment = rule.GetExtraQualityAdjustmentBySellIn(4);

            Assert.Equal(2, extraQualityAdjustment);
        }
    }
}
