// ****************************************************************************
// * Project:  BitFields
// * File:     BitField.cs
// * Author:   Latency McLaughlin
// * Date:     07/15/2014
// ****************************************************************************
using System;


namespace BitFields {
  /// <summary>
  ///   The BisField class exposes the following methods:
  ///   Initialization:
  ///   ------------------
  ///   BitField()      // Constructor
  ///   ClearField()    // ClearField clears all contents of the Field
  ///   FillField()     // FillField fills all contents of the Field
  ///   SetField()      // Setting the specified flag and turning all other flags off.
  ///   Operations:
  ///   SetOn()         // Setting the specified flag and leaving all other flags unchanged
  ///   SetOff()        // Unsetting the specified flag and leaving all other flags unchanged.
  ///   Toggle()        // Toggling the specified flag and leaving all other bits unchanged.
  ///   IsSet            // IsSet checks if the specified flag is set/on in the Field.
  ///
  ///   Conversion:
  ///   -----------------------
  ///   DecimalToFlag        // Convert a decimal value to a Flag FlagsAttribute value.
  ///   ToString.Decimal()   // Return a string representation of the Field in decimal (base 10) notation
  ///   ToString.Hex()       // Return a string representation of the Field in hexidecimal (base 16) notation.
  ///   ToString.Binary()    // Return a string representation of the Field in binary (base 2) notation.
  /// </summary>
  public class BitField : IFluentInterface {
    /// <summary>
    ///   Contructor
    ///   Add all initialization here
    /// </summary>
    public BitField() {
      ClearField();
      ToString = new ToStringSwitchBoard(this);
    }

    public BitField(ulong mask) {
      Mask = mask;
    }

    /// <summary>
    ///   Public property SET and GET to access the Field
    /// </summary>
    public ulong Mask { get; set; }

    /// <summary>
    ///   ClearField clears all contents of the Field
    ///   Set all bits to zero using the clear flag
    /// </summary>
    public void ClearField() {
      SetField(Flag.Clear);
    }

    /// <summary>
    ///   FillField fills all contents of the Field
    ///   Set all bits to zero using the negation of clear
    /// </summary>
    public void FillField() {
      SetField(~Flag.Clear);
    }

    /// <summary>
    ///   Setting the specified flag(s) and turning all other flags off.
    ///   - Bits that are set to 1 in the flag will be set to one in the Field.
    ///   - Bits that are set to 0 in the flag will be set to zero in the Field.
    /// </summary>
    /// <param name="flg">The flag to set in Field</param>
    private void SetField(Flag flg) {
      Mask = (ulong) flg;
    }

    /// <summary>
    ///   Setting the specified flag(s) and leaving all other flags unchanged.
    ///   - Bits that are set to 1 in the flag will be set to one in the Field.
    ///   - Bits that are set to 0 in the flag will be unchanged in the Field.
    /// </summary>
    /// <example>
    ///   OR truth table
    ///   0 | 0 = 0
    ///   1 | 0 = 1
    ///   0 | 1 = 1
    ///   1 | 1 = 1
    /// </example>
    /// <param name="flg">The flag to set in Field</param>
    public void SetOn(Flag flg) {
      Mask |= (ulong) flg;
    }

    /// <summary>
    ///   Unsetting the specified flag(s) and leaving all other flags unchanged.
    ///   - Bits that are set to 1 in the flag will be set to zero in the Field.
    ///   - Bits that are set to 0 in the flag will be unchanged in the Field.
    /// </summary>
    /// <example>
    ///   AND truth table
    ///   0 & 0 = 0
    ///   1 & 0 = 0
    ///   0 & 1 = 0
    ///   1 & 1 = 1
    /// </example>
    /// <param name="flg">The flag(s) to unset in Field</param>
    public void SetOff(Flag flg) {
      Mask &= ~(ulong) flg;
    }

    /// <summary>
    ///   Toggling the specified flag(s) and leaving all other bits unchanged.
    ///   - Bits that are set to 1 in the flag will be toggled in the Field.
    ///   - Bits that are set to 0 in the flag will be unchanged in the Field.
    /// </summary>
    /// <example>
    ///   XOR truth table
    ///   0 ^ 0 = 0
    ///   1 ^ 0 = 1
    ///   0 ^ 1 = 1
    ///   1 ^ 1 = 0
    /// </example>
    /// <param name="flg">The flag to toggle in Field</param>
    public void Toggle(Flag flg) {
      Mask ^= (ulong) flg;
    }

    /// <summary>
    ///   Checks if any/all of the specified flags are set/on in the Field.
    /// </summary>
    /// <param name="flg"></param>
    /// <param name="compareAll"></param>
    /// <returns>
    ///   true if flag(s) is set in Field
    ///   false otherwise
    /// </returns>
    public bool IsSet(Flag flg, bool compareAll = false) {
      return (!compareAll ? (Mask & (ulong) flg) != 0 : (Mask & (ulong) flg) == (ulong) flg);
    }

    /// <summary>
    ///   IsEqual checks if all the specified flags are the same as in the Field.
    /// </summary>
    /// <param name="flg">flag(s) to check</param>
    /// <returns>
    ///   true if all flags identical in the Field
    ///   false otherwise
    /// </returns>
    public bool IsEqual(Flag flg) {
      return Mask == (ulong) flg;
    }


    /// <summary>
    ///   Convert a decimal value to a Flag FlagsAttribute value.
    ///   Method is thread safe
    /// </summary>
    /// <param name="dec">Valid input: dec between 0,64 </param>
    /// <returns></returns>
    public static Flag DecimalToFlag(decimal dec) {
      var flg = Flag.Clear;
      ulong tMsk = 0;
      try {
        var shift = (byte) dec;
        if (shift > 0 && shift <= 64)
          tMsk = (ulong) 0x01 << (shift - 1);
        flg = (Flag) tMsk;
      } catch (OverflowException e) { //Byte cast operation
        Console.WriteLine("Exception caught in ToStringBin: {0}", e);
      }
      return flg;
    }

    // ///////////////////////////////////////////////////////////////////////////////
    // ToString override | Union 3-ways
    // ///////////////////////////////////////////////////////////////////////////////
    public interface IToString : IFluentInterface {
      String Decimal();
      String Hex();
      String Binary();
    }

    public new IToString ToString;

    private class ToStringSwitchBoard : IToString {
      private readonly BitField _bitField;

      public ToStringSwitchBoard(BitField bitField) {
        _bitField = bitField;
      }

      /// <summary>
      ///   Return a string representation of the Field in decimal (base10) notation.
      /// </summary>
      public String Decimal() {
        return String.Format("{0}", _bitField.Mask);
      }

      /// <summary>
      ///   Return a string representation of the Field in hexidecimal (base16) notation.
      /// </summary>
      public String Hex() {
        return String.Format("{0:x16}", _bitField.Mask).ToUpper();
      }

      /// <summary>
      ///   Return a string representation of the Field in binary (base2) notation.
      /// </summary>
      public String Binary() {
        return Convert.ToString((Int64) _bitField.Mask, 2);
      }
    }

  }
}