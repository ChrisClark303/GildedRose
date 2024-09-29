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

                UpdateItemQuality(item);

                item.SellIn--;
                if (item.SellIn < 0)
                {
                    HandleItemPastSellIn(item);
                }
            }
        }

        private static void UpdateItemQuality(Item item)
        {
            if (item.QualityIncreasesWithAge())
            {
                item.IncrementQualityIfNotAtMax();
                item.ApplySellInDependentQualityUpdate();
                return;
            } 

            item.DegradeQualityUntilMin();
        }

        private static void HandleItemPastSellIn(Item item)
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

            item.DegradeQualityUntilMin();
        }
    }
}