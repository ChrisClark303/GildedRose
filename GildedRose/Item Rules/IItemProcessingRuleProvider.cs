namespace GildedRoseKata
{
    public interface IItemProcessingRuleProvider
    {
        IItemProcessingRules GetRuleForItem(Item item);
    }
}
