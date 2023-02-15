using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CodingChallengesTests")]
namespace CodingChallenges
{
    public class Challenge01
    {
        //TODO:
        //Create a function that takes in a number and based on number finds out which cola brand is preferred
        //and returns result as a string.
        //Rules:
        // - If number is dividable by 3 then "Pepsi" is preferred
        // - If number is dividable by 5 then "Coke" is preferred
        // - If number is dividable by 3 and 5 then "Dr. Pepper" is preferred
        // - If no preferred brand is found, return empty string.
        // - Zero or negative input is not allowed.
        //
        //Check Unit tests project for possible tips. There might be also need to improve tests.
        public string PreferredColaBrand(int number)
        {
            if (number <= 0)
                throw new ArgumentException(
                    "Number less than equal to zero is not valid",
                    nameof(number));

            var isDivisibleBy3 = number % 3 is 0;
            var isDivisibleBy5 = number % 5 is 0;

            if (isDivisibleBy3 && isDivisibleBy5)
                return DrinkNameConstants.DrPepper;
            if (isDivisibleBy3)
                return DrinkNameConstants.Pepsi;
            if (isDivisibleBy5)
                return DrinkNameConstants.Coke;
            return string.Empty;
        }
    }

    internal static class DrinkNameConstants
    {
        internal const string Coke = nameof(Coke);
        internal const string Pepsi = nameof(Pepsi);
        internal const string DrPepper = "Dr. Pepper";
    }
}
