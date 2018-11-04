using System;
using System.Collections.Generic;
using System.Linq;
using AKQA.TechChallenge.SpellNumber.Core.Interfaces;
using AKQA.TechChallenge.SpellNumber.Core.Utility;

namespace AKQA.TechChallenge.SpellNumber.Core.Component
{
    public class NumberSpeller : INumberSpeller
    {
        public string SpellNumber(long number)      
        {
            var digits = number.ToString().Select(digit => int.Parse(digit.ToString())).Reverse().ToArray();

            var numberNames = new List<string>();

            // Calculate the triplets
            var tripletCount = (int)Math.Ceiling(digits.Length / 3.0);

            for (var tripletNumber = 0; tripletNumber < tripletCount; tripletNumber++)
            {
                var triplet = Triplet.ToText(digits, tripletNumber);
                if (string.IsNullOrEmpty(triplet))
                {
                    continue;
                }

                if (tripletCount > 0 && tripletNumber > 0)
                {
                    numberNames.Add(NumberMaps.Triplets[tripletNumber]);
                }

                numberNames.Add(triplet);
            }

            // Join all triplets
            var result = string.Join(" ", numberNames.AsEnumerable().Reverse());
            return result;
        }
       
    }

}