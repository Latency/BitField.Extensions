// *****************************************************************************
// File:      ToStringSwitchboard.cs
// Solution:  BitFields
// Date:      10/10/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;

namespace BitFields {
  internal class ToStringSwitchBoard : IToString {
    private readonly BitField _bitField;

    public ToStringSwitchBoard(BitField bitField) {
      _bitField = bitField;
    }

    /// <summary>
    ///   Return a string representation of the Field in decimal (base10) notation.
    /// </summary>
    public string Decimal() {
      return $"{_bitField.Mask}";
    }

    /// <summary>
    ///   Return a string representation of the Field in hexidecimal (base16) notation.
    /// </summary>
    public string Hex() {
      return $"{_bitField.Mask:x16}".ToUpper();
    }

    /// <summary>
    ///   Return a string representation of the Field in binary (base2) notation.
    /// </summary>
    public string Binary() {
      return Convert.ToString((long) _bitField.Mask, 2);
    }
  }
}