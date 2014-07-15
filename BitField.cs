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
  ///   BitField()		// Constructor
  ///   ClearField()	// ClearField clears all contents of the Field
  ///   FillField()		// FillField fills all contents of the Field
  ///   SetField()		// Setting the specified flag and turning all other flags off.
  ///   Operations:
  ///   SetOn()			// Setting the specified flag and leaving all other flags unchanged
  ///   SetOff()		// Unsetting the specified flag and leaving all other flags unchanged.
  ///   SetToggle()		// Toggling the specified flag and leaving all other bits unchanged.
  ///   IsOn			// IsOn checks if the specified flag is set/on in the Field.
  ///   Conversion:
  ///   DecimalToFlag	// Convert a decimal value to a Flag FlagsAttribute value.
  ///   ToStringDec()	// Return a string representation of the Field in decimal (base 10) notation
  ///   ToStringHex()	// Return a string representation of the Field in hexidecimal (base 16) notation.
  ///   ToStringBin()	// Return a string representation of the Field in binary (base 2) notation.
  /// </summary>
  public class BitField {
    /// <summary>
    ///   Contructor
    ///   Add all initialization here
    /// </summary>
    public BitField() {
      ClearField();
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
    public void SetToggle(Flag flg) {
      Mask ^= (ulong) flg;
    }

    /// <summary>
    ///   AnyOn checks if any of the specified flag are set/on in the Field.
    /// </summary>
    /// <param name="flg">flag(s) to check</param>
    /// <returns>
    ///   true if flag is set in Field
    ///   false otherwise
    /// </returns>
    public bool AnyOn(Flag flg) {
      return (Mask & (ulong) flg) != 0;
    }

    /// <summary>
    ///   AllOn checks if all the specified flags are set/on in the Field.
    /// </summary>
    /// <param name="flg">flag(s) to check</param>
    /// <returns>
    ///   true if all flags are set in Field
    ///   false otherwise
    /// </returns>
    public bool AllOn(Flag flg) {
      return (Mask & (ulong) flg) == (ulong) flg;
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

    /// <summary>
    ///   Return a string representation of the Field in
    ///   decimal (base10) notation.
    /// </summary>
    public String ToStringDec() {
      return String.Format("{0}", Mask);
    }

    /// <summary>
    ///   Return a string representation of the Field in hexidecimal (base16) notation.
    /// </summary>
    public String ToStringHex() {
      return String.Format("{0:x16}", Mask).ToUpper();
    }

    /// <summary>
    ///   Return a string representation of the Field in binary (base2) notation.
    /// </summary>
    public String ToStringBin() {
      return Convert.ToString((long) Mask, 2); //binary
    }
  }
}