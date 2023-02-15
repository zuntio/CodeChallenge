using CodingChallenges;
using System;
using Xunit;

namespace CodingChallengesTests
{
    public class Challenge01Tests
    {
        Challenge01 CreateSut() => new Challenge01();

        //TODO: Add more tests as needed

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void PepsiOrCokeShouldThrowOnZeroOrNegativeNumber(int number)
        {
            //Arrange
            var sut = CreateSut();

            //Act & Assert
            Assert.ThrowsAny<ArgumentException>(() => sut.PreferredColaBrand(number));
        }

        [Theory]
        [InlineData(1, "")]
        [InlineData(3, "Pepsi")]
        [InlineData(5, "Coke")]
        [InlineData(15, "Dr. Pepper")]
        [InlineData(77, "")]
        [InlineData(100, "Coke")]
        [InlineData(90, "Dr. Pepper")]
        public void PepsiOrCokeShouldReturnStringBasedOnNumber(int number, string exprectedResult)
        {
            //Arrange
            var sut = CreateSut();

            //Act
            var result = sut.PreferredColaBrand(number);

            //Assert
            Assert.Equal(exprectedResult, result);
        }
    }
}