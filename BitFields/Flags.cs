// *****************************************************************************
// File:      Flags.cs
// Solution:  BitFields
// Date:      10/10/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;

namespace BitFields {
  /// <summary>
  ///   The FlagsAttribute indicates that an enumeration can be treated
  ///   as a bit field; that is, a mask comprised of a set of flags.
  /// </summary>
  /// <remarks>
  ///   - Bit fields can be combined using a bitwise OR operation, whereas enumerated constants cannot.
  ///   This means that the results from bitwise operations are also bit fields
  ///   - Bit fields are generally used for lists of elements that might occur in combination,
  ///   whereas enumeration constants are generally used for lists of mutually exclusive elements.
  ///   Therefore, bit fields are designed to be combined to generate
  ///   unnamed values, whereas enumerated constants are not. Languages vary in their use of bit
  ///   fields compared to enumeration constants.
  ///   - The ulong keyword denotes a simple type that stores a 64-bit unsigned integer
  ///   so we can have up to a maximum of 64 unique flags with one enumeration of this type.
  /// </remarks>
  /// <example>
  ///   The clear flag is enumerated to zero, and used appropriately can be used clear the Field.
  /// </example>
  [Flags]
  public enum Flag : ulong {
                    // Hexidecimal          Decimal     Binary
    Clear = 0UL,    // 0x...0000            0           ...00000000000000000
    F1  = 1UL,      // 0x...0001            1           ...00000000000000001            
    F2  = F1  << 1, // 0x...0002            2           ...00000000000000010
    F3  = F2  << 1, // 0x...0004            4           ...00000000000000100
    F4  = F3  << 1, // 0x...0008            8           ...00000000000001000
    F5  = F4  << 1, // 0x...0010            16          ...00000000000010000
    F6  = F5  << 1, // 0x...0020            32          ...00000000000100000
    F7  = F6  << 1, // 0x...0040            64          ...00000000001000000
    F8  = F7  << 1, // 0x...0080            128         ...00000000010000000
    F9  = F8  << 1, // 0x...0100            256         ...00000000100000000
    F10 = F9  << 1, // 0x...0200            512         ...00000001000000000
    F11 = F10 << 1, // 0x...0400            1024        ...00000010000000000
    F12 = F11 << 1, // 0x...0800            2048        ...00000100000000000
    F13 = F12 << 1, // 0x...1000            4096        ...00001000000000000
    F14 = F13 << 1, // 0x...2000            8192        ...00010000000000000
    F15 = F14 << 1, // 0x...4000            16384       ...00100000000000000
    F16 = F15 << 1, // 0x...8000            32768       ...01000000000000000
    F17 = F16 << 1,
    F18 = F17 << 1,
    F19 = F18 << 1,
    F20 = F19 << 1,
    F21 = F20 << 1,
    F22 = F21 << 1,
    F23 = F22 << 1,
    F24 = F23 << 1,
    F25 = F24 << 1,
    F26 = F25 << 1,
    F27 = F26 << 1,
    F28 = F27 << 1,
    F29 = F28 << 1,
    F30 = F29 << 1,
    F31 = F30 << 1,
    F32 = F31 << 1,
    F33 = F32 << 1,
    F34 = F33 << 1,
    F35 = F34 << 1,
    F36 = F35 << 1,
    F37 = F36 << 1,
    F38 = F37 << 1,
    F39 = F38 << 1,
    F40 = F39 << 1,
    F41 = F40 << 1,
    F42 = F41 << 1,
    F43 = F42 << 1,
    F44 = F43 << 1,
    F45 = F44 << 1,
    F46 = F45 << 1,
    F47 = F46 << 1,
    F48 = F47 << 1,
    F49 = F48 << 1,
    F50 = F49 << 1,
    F51 = F50 << 1,
    F52 = F51 << 1,
    F53 = F52 << 1,
    F54 = F53 << 1,
    F55 = F54 << 1,
    F56 = F55 << 1,
    F57 = F56 << 1,
    F58 = F57 << 1,
    F59 = F58 << 1,
    F60 = F59 << 1,
    F61 = F60 << 1,
    F62 = F61 << 1,
    F63 = F62 << 1,
    F64 = F63 << 1
  }
}