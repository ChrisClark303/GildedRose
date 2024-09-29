using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class ItemExtensionTests
    {
        [Fact]
        public void DecrementQualityIfNotAtMin_ItemQualityMoreThanMin_AndStandardItem_ReducesQualityByOne()
        {
            Item item = new() { Quality = 10, Name = "Elixir of Mongoose" };

            item.DegradeQualityUntilMin();

            Assert.Equal(9, item.Quality);
        }

        [Fact]
        public void DecrementQualityIfNotAtMin_ItemQualityMoreThanMin_AndConjuredItem_ReducesQualityByOne()
        {
            Item item = new() { Quality = 10, Name = "Conjured Mana Cake" };

            item.DegradeQualityUntilMin();

            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void DecrementQualityIfNotAtMin_StandardItem_ItemQualityAtMin_DoesNotReduceQuality()
        {
            Item item = new() { Quality = 0 };

            item.DegradeQualityUntilMin();

            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void DecrementQualityIfNotAtMin_ConjuredItem_ItemQualityAtMin_DoesNotReduceQualityPastZero()
        {
            Item item = new() { Quality = 1, Name = "Conjured Mana Cake" };

            item.DegradeQualityUntilMin();

            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void IncrementQualityIfNotAtMax_ItemQualityLessThanMax_IncreasesQualityByOne()
        {
            Item item = new() { Quality = 10 };

            item.IncrementQualityIfNotAtMax();

            Assert.Equal(11, item.Quality);
        }

        [Fact]
        public void IncrementQualityIfNotAtMax_ItemQualityAtMax_DoesNotIncreaseQuality()
        {
            Item item = new() { Quality = 50 };

            item.IncrementQualityIfNotAtMax();

            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void AmendQualityByAmount_PositiveAmount_IncreasesQualityBySpecifiedAmount()
        {
            Item item = new() { Quality = 10 };

            item.AmendQualityByAmount(2);

            Assert.Equal(12, item.Quality);
        }

        [Fact]
        public void AmendQualityByAmount_PositiveAmount_DoesNotIncreasesQualityPastMax()
        {
            Item item = new() { Quality = 49 };

            item.AmendQualityByAmount(2);

            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void AmendQualityByAmount_NegativeAmount_DecreasesQualityBySpecifiedAmount()
        {
            Item item = new() { Quality = 10 };

            item.AmendQualityByAmount(-2);

            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void AmendQualityByAmount_NegativeAmount_DoesNotDecreasesQualityPastMin()
        {
            Item item = new() { Quality = 1 };

            item.AmendQualityByAmount(-2);

            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void SetQualityToMinimum_SetsItemQualityToZero()
        {
            Item item = new() { Quality = 50 };

            item.SetQualityToMinimum();

            Assert.Equal(0, item.Quality);
        }

        [Theory]
        [InlineData("Aged Brie", true)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", true)]
        [InlineData("+5 Dexterity Vest", false)]
        [InlineData("ItemX", false)]
        [InlineData("Sulfuras, Hand of Ragnaros", false)]
        public void QualityIncreasesWithAge_ReturnsCorrectBoolean_BasedOnItemName(string itemName, bool expected)
        {
            Item item = new() { Name = itemName };

            bool actual = item.QualityIncreasesWithAge();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Aged Brie", true)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", true)]
        [InlineData("+5 Dexterity Vest", true)]
        [InlineData("ItemX", true)]
        [InlineData("Sulfuras, Hand of Ragnaros", false)]
        public void RequiresQualityUpdates_ReturnsCorrectBoolean_BasedOnItemName(string itemName, bool expected)
        {
            Item item = new() { Name = itemName };

            bool actual = item.RequiresQualityUpdates();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Aged Brie", false)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", true)]
        [InlineData("+5 Dexterity Vest", false)]
        [InlineData("ItemX", false)]
        [InlineData("Sulfuras, Hand of Ragnaros", false)]
        public void ItemExpiresAfterSellIn_ReturnsCorrectBoolean_BasedOnItemName(string itemName, bool expected)
        {
            Item item = new() { Name = itemName };

            bool actual = item.ExpiresAfterSellIn();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Aged Brie", 5, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 1)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 2)]
        [InlineData("+5 Dexterity Vest", 5, 0)]
        [InlineData("ItemX", 5, 0)]
        [InlineData("Sulfuras, Hand of Ragnaros", 5, 0)]
        public void ApplySellInDependentQualityUpdates_ReturnsCorrectBoolean_BasedOnItemName(string itemName, int itemSellIn, int qualityAfterUpdate)
        {
            Item item = new() { Name = itemName, SellIn = itemSellIn, Quality = 0 };

            item.ApplySellInDependentQualityUpdate();

            Assert.Equal(qualityAfterUpdate, item.Quality);
        }

        [Fact]
        public void ApplySellInDependentQualityUpdates_DoesNotApplyQualityUpdate_PastMaxQuality()
        {
            Item item = new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 49 };

            item.ApplySellInDependentQualityUpdate();

            Assert.Equal(50, item.Quality);
        }
    }
}