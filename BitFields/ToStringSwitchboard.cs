// ****************************************************************************
// Project:  BtFields
// File:     ToStringSwitchboard.cs
// Author:   Latency McLaughlin
// Date:     01/09/2021
// ****************************************************************************

using System;

namespace BitFields {
    internal class ToStringSwitchBoard : IToString {
        private readonly BitField _bitField;

        internal ToStringSwitchBoard(BitField bitField) => _bitField = bitField;

        /// <summary>
        ///     Return a string representation of the Field in decimal (base10) notation.
        /// </summary>
        public string Decimal() => $"{_bitField.Mask}";

        /// <summary>
        ///     Return a string representation of the Field in hexidecimal (base16) notation.
        /// </summary>
        public string Hex() => $"{_bitField.Mask:x16}".ToUpper();

        /// <summary>
        ///     Return a string representation of the Field in binary (base2) notation.
        /// </summary>
        public string Binary() => Convert.ToString((long) _bitField.Mask, 2);
    }
}