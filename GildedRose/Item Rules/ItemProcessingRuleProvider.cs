using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{

    public class ItemProcessingRuleProvider : IItemProcessingRuleProvider
    {
        private readonly IDictionary<string, IItemProcessingRules> _rules;
        private readonly IItemProcessingRules _defaultRule;

        public ItemProcessingRuleProvider(IDictionary<string, IItemProcessingRules> rules, IItemProcessingRules defaultRule)
        {
            _rules = rules;
            _defaultRule = defaultRule;
        }

        public IItemProcessingRules GetRuleForItem(Item item)
        {
            _rules.TryGetValue(item.Name, out IItemProcessingRules rule);
            return rule ?? _defaultRule;
        }
    }
}
