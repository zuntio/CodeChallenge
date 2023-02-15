using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges
{
    public class Challenge02
    {
        //TODO: 
        //Create a function that returns list of Value added tax (Vat) Codes that are valid on a given local date (like "2021-12-31").
        //All possible values are already added to VatCodes list for you. Do not edit data in VatCodes list.
        //If given date is not valid and not in expected format, method should throw ArgumentException
        //Values should be returned in order, starting from highest vat value.
        //
        //Check Unit tests project for possible tips. There might be also need to improve tests.
        public List<VatCode> ValueAddedTaxCategoriesOn(string date)
        {
            throw new NotImplementedException();
        }

        // Data structure for holding information about vat on certain date period
        public class VatCode
        {
            public int Id;
            public string Name;
            public decimal Value;
            public string Description;
            public DateTime ValidityStartDate;
            public DateTime? ValidityEndDate;

            public VatCode(int id, string name, decimal value, string description, DateTime validityStartDate, DateTime? validityEndDate)
            {
                Id = id;
                Name = name;
                Value = value;
                Description = description;
                ValidityStartDate = DateTime.SpecifyKind(validityStartDate, DateTimeKind.Local);
                ValidityEndDate = validityEndDate.HasValue ? DateTime.SpecifyKind(validityEndDate.Value, DateTimeKind.Local) : (DateTime?)null;
            }

            public override string ToString()
            {
                return $"{Id} {Name} {Value} {Description} {ValidityStartDate:yyyy-MM-dd}-{ValidityEndDate:yyyy-MM-dd}";
            }
        }

        public List<VatCode> VatCodes = new List<VatCode>()
        {
            new VatCode(1, "ALV0", 0, "Alv 0%", new DateTime(1994, 6, 1), null),

            new VatCode(2, "ALV22", 22, "Alv 22%", new DateTime(1994, 6, 1), new DateTime(2010, 6, 30)),
            new VatCode(3, "ALV12", 12, "Alv 12%", new DateTime(1994, 6, 1), new DateTime(1994, 12, 31)),
            new VatCode(4, "ALV9", 9, "Alv 9%", new DateTime(1994, 6, 1), new DateTime(1994, 12, 31)),
            new VatCode(5, "ALV5", 5, "Alv 5%", new DateTime(1994, 6, 1), new DateTime(1994, 12, 31)),

            new VatCode(6, "ALV17", 17, "Alv 17%", new DateTime(1995, 1, 1), new DateTime(2009, 9, 30)),
            new VatCode(7, "ALV12", 12, "Alv 12%", new DateTime(1995, 1, 1), new DateTime(1997, 12, 31)),
            new VatCode(8, "ALV6", 6, "Alv 6%", new DateTime(1995, 1, 1), new DateTime(1997, 12, 31)),

            new VatCode(9, "ALV8", 8, "Alv 8%", new DateTime(1998, 1, 1), new DateTime(2010, 6, 30)),

            new VatCode(10, "ALV12", 12, "Alv 12%", new DateTime(2009, 10, 1), new DateTime(2010, 6, 30)),

            new VatCode(11, "ALV23", 23, "Alv 23%", new DateTime(2010, 7, 1), new DateTime(2012, 12, 31)),
            new VatCode(12, "ALV13", 13, "Alv 13%", new DateTime(2010, 7, 1), new DateTime(2012, 12, 31)),
            new VatCode(13, "ALV9", 9, "Alv 9%", new DateTime(2010, 7, 1), new DateTime(2012, 12, 31)),

            new VatCode(14, "ALV24", 24, "Alv 24%", new DateTime(2013, 1, 1), null),
            new VatCode(15, "ALV14", 14, "Alv 14%", new DateTime(2013, 1, 1), null),
            new VatCode(16, "ALV10", 10, "Alv 10%", new DateTime(2013, 1, 1), null)
        };
    }
}
