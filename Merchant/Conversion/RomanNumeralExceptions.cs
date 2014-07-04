using System;
using System.Linq;

namespace Merchant.Conversion
{
    internal static class RomanNumeralExceptions {
        // ReSharper disable UnusedMember.Local
        private enum FourRepetitionExceptions {
            XXXIX,
            CCCXC,
            MMMCM
        }
        // ReSharper restore UnusedMember.Local

        internal enum IllegalRepetitions {
            DD,
            LL,
            VV
        }

        private static bool HasFour(string roman) {
            return roman.Length > 4 && roman.Distinct().Count() == 2;
        }

        private static bool HasIllegalMultipleOfFive(string roman) {
            return Enum.GetValues(typeof(IllegalRepetitions))
                        .Cast<object>()
                        .Any(illegalSymbol => roman.Contains(illegalSymbol.ToString()));
        }

        private static bool HasFourConsecutive(string roman) {
            return roman.Length > 3 && roman.Distinct().Count() == 1;
        }

        public static bool FoundInvalid(string roman) {
            if (HasFour(roman)) {
                FourRepetitionExceptions parseCheck;
                if (!Enum.TryParse(roman, out parseCheck))
                    return true;
            }
            return HasIllegalMultipleOfFive(roman) ||
                   HasFourConsecutive(roman);
        }
    }
}