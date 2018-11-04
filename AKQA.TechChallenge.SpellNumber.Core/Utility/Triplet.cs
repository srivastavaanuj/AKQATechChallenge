using System;
using System.Collections.Generic;
using System.Linq;

namespace AKQA.TechChallenge.SpellNumber.Core.Utility
{
    internal class Triplet
    {
        private readonly int[] _digits;
        private readonly int _tripletNumber;

        private Triplet(int[] digits, int tripletNumber)
        {
            _digits = digits;
            _tripletNumber = tripletNumber;
        }

        private bool HasOnes => Length >= 1;
        private bool HasTens => Length >= 2;
        private bool HasHundreds => Length == 3;

        private int Ones => _digits[0];

        private int Tens => _digits[1];

        private int Hundreds => _digits[2];

        private int Length => _digits.Length;

        public override string ToString()
        {
            var result = new List<string>();

            if (HasHundreds && Hundreds > 0)
            {
                result.Add(NumberMaps.Ones[Hundreds]);
                result.Add(NumberMaps.Triplets[0]);
            }

            if (HasTens && Tens > 0)
            {
                if (Tens > 0 && Tens < 2)
                {
                    result.Add(NumberMaps.Teens[Ones]);
                }
                else if (Tens >= 2)
                {
                    result.Add(NumberMaps.Tens[Tens - 2]);
                }
            }

            if (!HasOnes) return string.Join(" ", result);
            if (Ones == 0 && Length == 1 && _tripletNumber == 0)
            {
                result.Add(NumberMaps.Ones[Ones]);
            }
            else if (Length == 1 || (Length == 3 && Tens == 0 && Ones != 0))
            {
                result.Add(NumberMaps.Ones[Ones]);
            }
            else if (HasTens && Tens >= 2 && Ones > 0)
            {
                result.Add(NumberMaps.Ones[Ones]);
            }
            return string.Join(" ", result);
        }

        // Gets digits for a triplet
        private static int[] GetDigits(IReadOnlyCollection<int> digits, int tripletNumber)
        {
            var from = tripletNumber * 3;
            var to = tripletNumber * 3 + 2;

            var lastIndex = digits.Count - 1;

            if (from > lastIndex)
            {
                return null;
            }

            if (to > lastIndex)
            {
                to = lastIndex;
            }

            var tripletDigits = digits.Where((digit, i) => i >= from && i <= to).ToArray();
            return tripletDigits;
        }

        public static string ToText(int[] digits, int tripletNumber)
        {
            var tripletDigits = GetDigits(digits, tripletNumber);
            var triplet = new Triplet(tripletDigits, tripletNumber);
            return triplet.ToString();
        }
    }
}
