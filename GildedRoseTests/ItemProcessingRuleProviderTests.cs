using GildedRoseKata;
using System.Collections.Generic;
using System.Data;
using Xunit;

namespace GildedRoseTests
{
    public class ItemProcessingRuleProviderTests
    {
        [Fact]
        public void GetRulesForItem_WhenGivenItem_ReturnsCorrectRuleForItem()
        {
            ItemProcessingRules agedBrie = new(1, false);
            NoUpdateRule sulfuras = new();
            Dictionary<string, IItemProcessingRules> rules = new()
            {
                { "Sulfuras", sulfuras },
                { "Aged Brie", agedBrie }
            };

            ItemProcessingRuleProvider processingRules = new(rules, new ItemProcessingRules(-1, false));
            var rule = processingRules.GetRuleForItem(new Item { Name = "Sulfuras"});

            Assert.Equal(sulfuras, rule);
        }

        [Fact]
        public void GetRulesForItem_WhenGivenItemAndNoMatchingRuleForItem_ReturnsDefaultRule()
        {
            ItemProcessingRules agedBrie = new (1, false);
            NoUpdateRule sulfuras = new ();
            ItemProcessingRules defaultRule = new(-1, false);

            Dictionary<string, IItemProcessingRules> rules = new()
            {
                { "Sulfuras", sulfuras },
                { "Aged Brie", agedBrie }
            };

            ItemProcessingRuleProvider processingRules = new(rules, defaultRule);
            var rule = processingRules.GetRuleForItem(new Item { Name = "Backstage passes" });

            Assert.Equal(defaultRule, rule);
        }
    }
}  
