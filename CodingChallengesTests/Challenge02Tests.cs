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
        [InlineData("1997-12-31", 22, 17, 12, 6, 0)]
        [InlineData("1998-01-01", 22, 17, 8 ,0)]
        [InlineData("2010-06-30", 22, 12, 8 ,0)]
        [InlineData("2010-07-01", 23, 13, 9 ,0)]
        [InlineData("2013-01-01", 24, 14, 10 ,0)]
        public void ShouldReturnExpectedCatergoriesOnGivenDate(string date, params int[] expectedValues)
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
    }
}
