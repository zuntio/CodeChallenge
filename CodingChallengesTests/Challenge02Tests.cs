using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingChallengesTests
{
    public class Challenge02Tests
    {
        Challenge02 CreateSut() => new Challenge02();

        //TODO: Create more or improve existing tests as needed

        [Fact]
        public void ShouldThrowOnInvalidDate()
        {
            //Arrange
            var sut = CreateSut();

            //Act & Assert
            Assert.ThrowsAny<ArgumentException>(() => sut.ValueAddedTaxCategoriesOn("2021-02-29"));
        }

        [Fact]
        public void ShouldNotReturnAnythingBefore19940601()
        {
            //Arrange
            var sut = CreateSut();

            //Act
            var result = sut.ValueAddedTaxCategoriesOn("1994-05-31");

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ShouldReturnNotEndedTaxCategories()
        {
            //Arrange
            var sut = CreateSut();

            //Act
            var result = sut.ValueAddedTaxCategoriesOn("2021-12-31");

            //Assert
            Assert.True(result.Count == 4);
            Assert.Equal(24, result[0].Value);
            Assert.Equal(14, result[1].Value);
            Assert.Equal(10, result[2].Value);
            Assert.Equal(0, result[3].Value);
        }

        [Theory]
        [InlineData("1997-12-31", 22, 17, 12, 6, 0)]
        [InlineData("1998-01-01", 22, 17, 8 ,0)]
        [InlineData("2010-06-30", 22, 12, 8 ,0)]
        [InlineData("2010-07-01", 23, 13, 9 ,0)]
        [InlineData("2013-01-01", 24, 14, 10 ,0)]
        public void ShouldReturnExpectedCategoriesOnGivenDate(string date, params int[] expectedValues)
        {
            //Arrange
            var sut = CreateSut();

            //Act
            var result = sut.ValueAddedTaxCategoriesOn(date);

            //Assert
            Assert.Equal(expectedValues.Length, result.Count);

            for (int i = 0; i < expectedValues.Length; i++)
                Assert.Equal(expectedValues[i], result[i].Value);
        }

        [Fact]
        public void ShouldHaveAllVatCodesConsistentlyNamedAndDescribed()
        {
            var sut = CreateSut();
            var nameTemplate = "ALV{0}";
            var descriptionTemplate = "Alv {0}%";

            var vatCodes = sut.VatCodes;
            
            Assert.All(vatCodes,
                v =>
                {
                    Assert.Equal(string.Format(nameTemplate, v.Value), v.Name);
                    Assert.Equal(string.Format(descriptionTemplate, v.Value), v.Description);
                });
        }

        [Fact]
        public void ShouldHaveUniqueIdOnAllVatCodeEntries()
        {
            var sut = CreateSut();

            var vatCodes = sut.VatCodes;

            var ids = vatCodes.Select(v => v.Id).ToList();
            var distinctIds = ids.Distinct();
            
            Assert.Equal(distinctIds, ids);
        }

        [Fact]
        public void ShouldNotHaveOverlappingTimelinesInVatCodeEntries()
        {
            var sut = CreateSut();

            var vatCodesByValue = sut.VatCodes.ToLookup(k => k.Value);

            foreach (var vatCodeType in vatCodesByValue.Where(v => v.Count() > 1))
            {
                var ordered = vatCodeType.OrderBy(v => v.ValidityStartDate).ToArray();
                for (int i = 1; i < ordered.Length; i++)
                {
                    var previous = ordered[i - 1];
                    var current = ordered[i];
                    Assert.NotNull(previous.ValidityEndDate);
                    Assert.True(previous.ValidityStartDate < previous.ValidityEndDate);
                    Assert.True(current.ValidityStartDate > previous.ValidityEndDate);
                    Assert.True(current.ValidityEndDate is null || current.ValidityEndDate > current.ValidityStartDate);
                }
            }
        }
    }
}
