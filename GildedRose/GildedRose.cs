using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items; //no accessor, name not correct for a field.
        
        private readonly ItemProcessingRuleProvider _rulesProvider;

        public GildedRose(IList<Item> Items, ItemProcessingRuleProvider rulesProvider = null)
        {
            this.Items = Items;
            _rulesProvider = rulesProvider;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                var itemRule = _rulesProvider?.GetRuleForItem(item);
                if (itemRule != null && !itemRule.RequiresQualityUpdate) continue;

                UpdateItemQuality(item, itemRule);

                item.SellIn--;
                if (item.SellIn < 0)
                {
                    HandleItemPastSellIn(item, itemRule);
                }
            }
        }

        private static void UpdateItemQuality(Item item, IItemProcessingRules rules)
        {
            if (item.QualityIncreasesWithAge())
            {
                item.AmendQualityByAmount(rules.DailyQualityAdjustment);
                item.ApplySellInDependentQualityUpdate();
                return;
            }

            item.AmendQualityByAmount(rules.DailyQualityAdjustment);
        }

        private static void HandleItemPastSellIn(Item item, IItemProcessingRules rules)
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

            item.AmendQualityByAmount(rules.DailyQualityAdjustment);
        }
    }
}