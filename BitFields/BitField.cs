// *****************************************************************************
// File:      BitField.cs
// Solution:  BitFields
// Date:      10/10/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;

namespace BitFields {
  /// <inheritdoc />
  /// <summary>
  ///   The BitField class exposes the following methods:
  ///   Initialization:
  ///   ------------------
  ///   BitField()      // Constructor
  ///   BitField(ulong) // Copy Constructor
  ///   Mask            // Property used to hold the bitmask value.
  ///   ClearField()    // ClearField clears all contents of the Field.
  ///   FillField()     // FillField fills all contents of the Field.
  ///   SetField()      // Setting the specified flag and turning all other flags off.
  ///   Operations:
  ///   -----------------------
  ///   SetOn()         // Setting the specified flag and leaving all other flags unchanged.
  ///   SetOff()        // Unsetting the specified flag and leaving all other flags unchanged.
  ///   Toggle()        // Toggling the specified flag and leaving all other bits unchanged.
  ///   IsSet()         // IsSet checks if the specified flag is set/on in the Field.
  ///   IsEqual()       // Compares the bitmask with another and tests if equal.
  ///   Conversion:
  ///   -----------------------
  ///   DecimalToFlag()      // Convert a decimal value to a Flag FlagsAttribute value.
  ///   ToString.Decimal()   // Return a string representation of the Field in decimal (base 10) notation.
  ///   ToString.Hex()       // Return a string representation of the Field in hexidecimal (base 16) notation.
  ///   ToString.Binary()    // Return a string representation of the Field in binary (base 2) notation.
  /// </summary>
  public class BitField : IFluentInterface {
    /// <summary>
    ///   Polymorphic class object
    /// </summary>
    public new IToString ToString;

    /// <summary>
    ///   Contructor
    ///   Add all initialization here
    /// </summary>
    public BitField() {
      ClearField();
      ToString = new ToStringSwitchBoard(this);
    }

    /// <summary>
    ///   Copy Contructor
    /// </summary>
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
      SetField(0UL);
    }

    /// <summary>
    ///   FillField fills all contents of the Field
    ///   Set all bits to zero using the negation of clear
    /// </summary>
    public void FillField() {
      SetField(~0UL);
    }

    /// <summary>
    ///   Setting the specified flag(s) and turning all other flags off.
    ///   - Bits that are set to 1 in the flag will be set to one in the Field.
    ///   - Bits that are set to 0 in the flag will be set to zero in the Field.
    /// </summary>
    /// <param name="mask">The mask to set in Field</param>
    private void SetField(ulong mask) {
      Mask = mask;
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
    /// <param name="mask">The mask to set in Field</param>
    public void SetOn(ulong mask) {
      Mask |= mask;
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
    /// <param name="mask">The mask to unset in Field</param>
    public void SetOff(ulong mask) {
      Mask &= ~mask;
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
    /// <param name="mask">The mask to toggle in Field</param>
    public void Toggle(ulong mask) {
      Mask ^= mask;
    }

    /// <summary>
    ///   Checks if any/all of the specified flags are set/on in the Field.
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="compareAll"></param>
    /// <returns>
    ///   true if flag(s) is set in Field
    ///   false otherwise
    /// </returns>
    public bool IsSet(ulong mask, bool compareAll = false) {
      return !compareAll ? (Mask & mask) != 0 : (Mask & mask) == mask;
    }

    /// <summary>
    ///   IsEqual checks if all the specified flags are the same as in the Field.
    /// </summary>
    /// <param name="mask">The mask to check</param>
    /// <returns>
    ///   true if all flags identical in the Field
    ///   false otherwise
    /// </returns>
    public bool IsEqual(ulong mask) {
      return Mask == mask;
    }

    /// <summary>
    ///   Convert a decimal value to a Flag FlagsAttribute value.
    ///   Method is thread safe
    /// </summary>
    /// <param name="dec">Valid input: dec between 0,64 </param>
    /// <returns>The bitmask of the decimal value</returns>
    public static ulong DecimalToFlag(decimal dec) {
      ulong tMsk = 0;
      try {
        var shift = (byte) dec;
        if (shift > 0 && shift <= 64)
          tMsk = (ulong) 0x01 << (shift - 1);
      } catch (OverflowException e) { //Byte cast operation
        Console.WriteLine("Exception caught in ToStringBin: {0}", e);
      }
      return tMsk;
    }
  }
}