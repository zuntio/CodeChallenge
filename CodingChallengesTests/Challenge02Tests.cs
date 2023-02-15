using CodingChallenges;
using System;
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
        [InlineData("1997-12-31", "ALV22,ALV17,ALV12,ALV6,ALV0")]
        [InlineData("1998-01-01", "ALV22,ALV17,ALV8,ALV0")]
        [InlineData("2010-06-30", "ALV22,ALV12,ALV8,ALV0")]
        [InlineData("2010-07-01", "ALV23,ALV13,ALV9,ALV0")]
        [InlineData("2013-01-01", "ALV24,ALV14,ALV10,ALV0")]
        public void ShouldReturnExpectedCatergoriesOnGivenDate(string date, string expectedCategories)
        {
            //Arrange
            var sut = CreateSut();

            //Act
            var result = sut.ValueAddedTaxCategoriesOn(date);

            //Assert
            var categories = expectedCategories.Split(',');
            Assert.True(result.Count == categories.Length);

            var resultCategories = result.Select(x => x.Name).Aggregate("", (a, b) => $"{a}{(a.Any() ? "," : "")}{b}");
            Assert.Equal(expectedCategories, resultCategories);
            
        }
    }
}
