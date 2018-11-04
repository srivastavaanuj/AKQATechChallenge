using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKQA.TechChallenge.SpellNumber.Core.Utility
{
    internal static class NumberMaps
    {
        internal static readonly string[] Ones =
        {
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
        };

        internal static readonly string[] Teens =
        {
            "Ten",
            "Eleven",
            "Twelve",
            "Thirteen",
            "Fourteen",
            "Fifteen",
            "Sixteen",
            "Seventeen",
            "Eighteen",
            "Nineteen"
        };

        internal static readonly string[] Tens =
        {
            "Twenty",
            "Thirty",
            "Forty",
            "Fifty",
            "Sixty",
            "Seventy",
            "Eighty",
            "Ninety"
        };

        //can be extended
        internal static readonly string[] Triplets =
        {
            "Hundred",
            "Thousand",
            "Million",
            "Billion",
            "Trillion",
        };
    }
}