﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class ItemProcessingRule : IItemProcessingRules
    {
        private readonly SellInQualityAdjustmentRule[] _sellInQualityAdjustmentRules = [];

        public ItemProcessingRule(int dailyQualityAdjustment, bool expiresAfterSellIn = false, params SellInQualityAdjustmentRule[] sellInQualityAdjustmentRules)
        {
            DailyQualityAdjustment = dailyQualityAdjustment;
            ExpiresAfterSellIn = expiresAfterSellIn;
            _sellInQualityAdjustmentRules = sellInQualityAdjustmentRules;
        }

        public bool RequiresQualityUpdate { get; private init; } = true;
        public bool ExpiresAfterSellIn { get; }
        public int DailyQualityAdjustment { get; }
        public int GetExtraQualityAdjustmentBySellIn(int sellIn)
        {
            return _sellInQualityAdjustmentRules.Where(r => sellIn <= r.SellInThreshold)
                .Sum(r => r.QualityAdjustment);
        }
    }
}
