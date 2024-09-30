using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class ItemExtensionTests
    {
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
    }
}