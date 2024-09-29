using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class ItemExtensionTests
    {
        [Fact]
        public void DecrementQualityIfNotAtMin_ItemQualityMoreThanMin_ReducesQualityByOne()
        {
            Item item = new() { Quality = 10 };

            item.DecrementQualityIfNotAtMin();

            Assert.Equal(9, item.Quality);
        }

        [Fact]
        public void DecrementQualityIfNotAtMin_ItemQualityAtMin_DoesNotReduceQuality()
        {
            Item item = new() { Quality = 0 };

            item.DecrementQualityIfNotAtMin();

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
        [InlineData("Aged Brie", false)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", true)]
        [InlineData("+5 Dexterity Vest", false)]
        [InlineData("ItemX", false)]
        [InlineData("Sulfuras, Hand of Ragnaros", false)]
        public void HasSellInDependentQualityUpdates_ReturnsCorrectBoolean_BasedOnItemName(string itemName, bool expected)
        {
            Item item = new() { Name = itemName };

            bool actual = item.HasSellInDependentQualityUpdates();

            Assert.Equal(expected, actual);
        }
    }
}