using GildedRoseKata;
using System.Collections.Generic;
using System.Data;
using Xunit;

namespace GildedRoseTests
{
    public class ItemProcessingRulesTests
    {
        [Fact]
        public void GetRulesForItem_WhenGivenItem_ReturnsCorrectRuleForItem()
        {
            ItemProcessingRule agedBrie = new(1, false);
            NoUpdateRule sulfuras = new();
            Dictionary<string, IItemProcessingRules> rules = new()
            {
                { "Sulfuras", sulfuras },
                { "Aged Brie", agedBrie }
            };

            ItemProcessingRuleProvider processingRules = new(rules, new ItemProcessingRule(-1, false));
            var rule = processingRules.GetRuleForItem(new Item { Name = "Sulfuras"});

            Assert.Equal(sulfuras, rule);
        }

        [Fact]
        public void GetRulesForItem_WhenGivenItemAndNoMatchingRuleForItem_ReturnsDefaultRule()
        {
            ItemProcessingRule agedBrie = new (1, false);
            NoUpdateRule sulfuras = new ();
            ItemProcessingRule defaultRule = new(-1, false);

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
