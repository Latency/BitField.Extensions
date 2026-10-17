# BitField.Extensions
 
.NET Library For BitField & Enum Extensions
 
| | Description |
|---|---|
| ASSEMBLY NAME: | BitField.Extensions |
| CREATED BY: | [Latency McLaughlin] |
| UPDATED: | 10/16/2026 |
| FRAMEWORKS: | net45, net451, net452, net46, net461, net462, net47, net471, net472, net48, net481, netstandard2.0, netstandard2.1, net8.0, net9.0, net10.0, net11.0 |
| LANGUAGE: | [C#] preview |
| OUTPUT TYPE: | [Library] [API] |
| SUPPORTS: | [Visual Studio] |
| GFX SUBSYS: | [None] |
| TAGS: | [BitFields], [C#], [Enums], [Library] |
| STATUS: | [![workflow-badge](https://github.com/Latency/BitField.Extensions/actions/workflows/status.yml/badge.svg)](https://github.com/Latency/BitField.Extensions/actions/workflows/status.yml) |
| LICENSE: | [![license-badge](https://img.shields.io/github/license/Latency/BitField.Extensions?logo=GitHub&style=plastic&logoColor=black&label=License&color=yellowgreen)](https://github.com/Latency/BitField.Extensions/blob/master/MIT-LICENSE.txt) |
| VERSION: | 1.0.5 |
 
---

## Navigation

* [Screenshots](#screenshots)
* [Introduction](#introduction)
* [Background](#background)
* [Storage](#storage)
* [Understanding bit shifting <<](#understanding-bit-shifting-)
* [Understanding bitwise operations](#understanding-bitwise-operations)
* [Usage](#usage)
* [Quick start](#quick-start)
* [Methods](#methods)
* [Points of Interest](#points-of-interest)
* [Installation](#installation)
* [References](#references)
* [Report An Issue](#report-an-issue)
* [Donation](#donation)
* [License](#license)

---

## Screenshots

![Sample image](http://bio-hazard.us/bitfields/images/BitFields.jpg)

## Introduction

This article demonstrates a simple use of bit fields as flags for Windows forms. Bit fields allow packaging of data into simple structures, and they are particularly useful when bandwidth, memory or data storage is at a premium. This might not appear to be an issue with modern day equipment or every day applications, but we can save up to 16 times more memory and storage when using bit fields instead of other value types such as boolean.

## Background

### Storage

Consider a boolean value in .NET:

```cs
bool bVal;
```

Boolean value data types are stored as 16-bit (2-byte) numbers that can only be true or false. Consider an unsigned 16-bit number which ranges from 0 to 65535:

```text
Decimal        Hexidecimal    Binary
0              0x0000         0000000000000000
65535          0xffff         1111111111111111
```

When numeric data types are converted to boolean values, 0 becomes false and all other values become true. When Boolean values are converted to numeric types, false becomes 0 and true becomes -1 (using a signed number).

If we want to use a boolean value to represent a two-state value of a flag or setting in our program (true <=> on, false <=> off), then this would be stored as a 16-bit number.

Consider using a binary digit to represent the same two-state value: (1 <=> on, 0 <=> off):

```text
Decimal        Hexidecimal    Binary
0              0x0000         0000000000000000
1              0x0001         0000000000000001
```

We can use this same 16-bit number to represent 16 unique settings by inspecting each digit and determining if it is 1/on or 0/off:

```text
Decimal        Hexidecimal    Binary
1              0x0001         0000000000000001
2              0x0002         0000000000000010
4              0x0004         0000000000000100
8              0x0008         0000000000001000
16             0x0010         0000000000010000
32             0x0020         0000000000100000
64             0x0040         0000000001000000
128            0x0080         0000000010000000
256            0x0100         0000000100000000
512            0x0200         0000001000000000
1024           0x0400         0000010000000000
2048           0x0800         0000100000000000
4096           0x1000         0001000000000000
8192           0x2000         0010000000000000
16384          0x4000         0100000000000000
32768          0x8000         1000000000000000
```

With only 16 settings, this might not appear to be an issue and one would more than likely store the settings as Boolean values, however, storing a history of those settings can quickly add up, and saving space by a factor of 16 can make a difference. Ever tried loading a 100MB file into memory and then manipulating it? How about a 1.6GB file?

### Understanding bit shifting <<

```cs
f1 = 0x01        // 0x01        1    00000001
f2 = f1 << 1,    // 0x02        2    00000010
f3 = f2 << 1,    // 0x04        4    00000100
f4 = f3 << 1,    // 0x08        8    00001000
```

Shifting to the Left or the Right.

There are two operators:

- `<<` for shifting a specified number of bits to the left (towards the "high order" bits)
- `>>` for shifting to the right. 

If a shift operation causes some number of bits to go outside of an underlying data type, then those bits are discarded. Empty bit positions created by the shift operation are always filled with 0s in a left shift operation and in a positive right shift operation. If a negative number of bit places is requested in a right shift operation `f2 >> -2`, then the vacated bit positions are filled with 1s.

### Understanding bitwise operations

Bitwise operations are used to manipulate the bit field, and determine if a specified flag is set. The following truth tables illustrate the truth values of some operations:

```text
Mask OR Flag     Mask AND NOT Flag    Mask XOR Flag        
0 | 0 = 0        0 & ~0 = 0           0 ^ 0 = 0                     
1 | 0 = 1        1 & ~0 = 1           1 ^ 0 = 1                     
0 | 1 = 1        0 & ~1 = 0           0 ^ 1 = 1                     
1 | 1 = 1        1 & ~1 = 0           1 ^ 1 = 0
```

## Usage

The `BitField` class/structure uses an enumeration to define the flags in the bit field. The field can store up to 64 unique flags using the 64-bit unsigned `ulong` value type. The flags can have any name, but be careful with the `Clear` flag as this has a special value that is used to clear and fill the entire bit field.

```cs
[Flags]
public enum Flag : ulong {
  Clear  = 0x00,
  f1     = 0x01,
  f2     = f1 << 1,
  . . .
}
```

Each `Flag` enumeration is a number that in binary form has one digit set to 1 and the rest set to 0. With this enumeration, there are exactly 64 distinct values with a single 1, and 2^64 (18446744073709551616) possible combinations of these 64 flags.

Some points to make about `[FlagsAttribute] == [Flags]`:

- An enumeration is treated as a bit field; that is, a mask comprised of a set of flags.
- The results from bitwise operations are also bit fields.
- Bit fields are generally used for lists of elements that might occur in combination, whereas enumeration constants are generally used for lists of mutually exclusive elements. Therefore, bit fields are designed to be combined to generate unnamed values, whereas enumerated constants are not. 

The bit field is stored in the variable `_Mask`, and external access is provided through the public properties `get` and `set`.

```cs
private ulong _Mask;    
public ulong Mask {
  get {
    return _Mask;
  }
  set {
    _Mask = value;
  }
}
```

### Quick start

Flags are passed to the `BitField` methods as `ulong` masks:

```cs
[Flags]
public enum Options : ulong {
  None  = 0,
  Bold  = 1UL << 0,
  Italic = 1UL << 1,
  Underline = 1UL << 2
}

var field = new BitField();
field.SetOn((ulong)(Options.Bold | Options.Italic));   // turn flags on
field.SetOff((ulong)Options.Italic);                   // turn a flag off
field.Toggle((ulong)Options.Underline);                // flip a flag
bool anyOn = field.IsSet((ulong)Options.Bold);         // true if any flag is on
bool allOn = field.IsSet((ulong)(Options.Bold | Options.Underline), true); // true if all flags are on
field.ClearField();                                    // all flags off
field.FillField();                                     // all flags on
```

## Methods

The `SetField` method sets the specified flag in the mask and turns all other flags off.

- Bits that are set to 1 in the flag will be set to one in the mask.
- Bits that are set to 0 in the flag will be set to zero in the mask. 

```cs
private void SetField(Flag flg) {
  Mask = (ulong)flg;
}
```

This is particularly useful for setting all bits off using the `Flag.Clear` flag `SetField(Flag.Clear)`,

```text
       Mask =  Flag.Clear
<=>    Mask =  0000000000000000000000000000000000000000000000000000000000000000
```

or setting all bits on using the negation of the `Flag.Clear` flag `SetField(~Flag.Clear)`.

```text
       Mask = ~Flag.Clear
<=>    Mask = ~0000000000000000000000000000000000000000000000000000000000000000
<=>    Mask =  1111111111111111111111111111111111111111111111111111111111111111
```

The `SetOn` method sets the specified flag(s) in the mask and leaves all other flags unchanged (using the binary bitwise inclusive OR operator).

- Bits that are set to 1 in the flag will be set to one in the mask.
- Bits that are set to 0 in the flag will be unchanged in the mask. 

```cs
public void SetOn(Flag flg) {
  Mask |= (ulong)flg;
}
```

Since a flag has exactly one digit with a value of 1, and the rest of the digits 0, this will leave the mask unchanged, except for the position(s) where there is a value 1:

Consider this operation on a random 16-bit Mask:

```text
           1101001000011001
    OR     F2
    -------------------------
<=>        1101001000011001
    OR     0000000000000010
    -------------------------
<=>        1101001000011011
```

This has the same effect as placing the digit 1 into the appropriate position in the Mask to set the flag to on.

The `SetOff` method sets the specified flag(s) off in the mask and leaves all other flags unchanged (using the unary bitwise complement NOT, followed by the binary bitwise AND operator).

- Bits that are set to 1 in the flag will be set to zero in the mask.
- Bits that are set to 0 in the flag will be unchanged in the mask. 

```cs
public void SetOff(Flag flg) {
  Mask &= ~(ulong)flg;
}
```

Since a flag has exactly one digit with a value of 1, and the rest of the digits 0, this will leave the mask unchanged, except for the position(s) where there is a value 1:

Consider this operation on a random 16-bit Mask:

```text
            1101001000011001
    AND    ~F1
    --------------------------
<=>         1101001000011001
    AND    ~0000000000000001
    --------------------------
<=>         1101001000011001
    AND     1111111111111110
    --------------------------
<=>         1101001000011000
```

This has the same effect as placing the digit 0 into the appropriate position in the Mask to set the flag to off.

The `SetToggle` method toggles the specified flag and leaves all other bits unchanged (using the binary bitwise exclusive OR, XOR operator).

- Bits that are set to 1 in the flag will be toggled in the mask.
- Bits that are set to 0 in the flag will be unchanged in the mask. 

```cs
public void SetToggle(Flag flg) {
  Mask ^= (ulong)flg;
}
```

Since a flag has exactly one digit with a value of 1, and the rest of the digits 0, this will leave the mask unchanged, except for the position where there is a value 1:

Consider this operation on a random 16-bit Mask:

```text
           1101001000011001
    XOR    F1
    -------------------------
<=>        1101001000011001
    XOR    0000000000000001
    -------------------------
<=>        1101001000011000
```

This has the same effect as placing the opposite digit in the appropriate position in the Mask to toggle the flag. Using this flag, we don't have to remember the previous state of the flag.

The `AnyOn` method checks if any of the specified flag(s) are set to on in the mask. It isolates the appropriate digit(s) and returns true if any are non zero, false otherwise.

```cs
public bool AnyOn (Flag flg) {
  return (Mask & (ulong)flg) != 0;
}
```

The `AllOn` method checks if all of the specified flag(s) are set to on in the mask. It isolates the appropriate digit(s) and returns true if they all are non zero, false otherwise.

```cs
public bool AllOn (Flag flg) {
  return (Mask & (ulong)flg) == (ulong)flg;
}
```

The `IsEqual` method checks if all of the specified flag(s) are the same as in the mask. It isolates the appropriate digit(s) and returns true if they are all the same, false otherwise.

```cs
public bool IsEqual (Flag flg) {
  return Mask == (ulong)flg;
}
```

The `DecimalToFlag` method converts a decimal value to a `Flag FlagsAttribute` value. The input can be a index between 0 and 64, and the output will be the `Flag` enumeration corresponding to that index. All it does is take the index, and shift a bit that many positions.

```cs
public static Flag DecimalToFlag(decimal dec) {
  Flag flg = Flag.Clear;
  ulong tMsk = 0;
  byte shift;
  try {
    shift = (byte)dec;
    if (shift > 0 && shift <= 64)
      tMsk = (ulong) 0x01 << (shift - 1);
    flg = (Flag)tMsk;
  } catch (OverflowException e) {   //Byte cast operation
    Console.WriteLine("Exception caught in DecimalToFlag: {0}", e.ToString());
  }
  return flg;
}
```

The three methods `ToStringDec`, `ToStringHex`, `ToStringBin` return a string representation of the mask in decimal, hexadecimal, and binary notation respectively.

#### Using the BitField class/structure.

Instantiating the object is straight forward:

```cs
BitField bitField = new BitField();
```

When creating the `struct` object using the `new` operator, it gets created and the appropriate constructor is called. Unlike classes, `struct`s can be instantiated without using the `new` operator, so if you do not use `new`, the fields will remain unassigned and the object cannot be used until all of the fields are initialized.

This will create a new bit field and set all flags off. To set all flags on, you can call the method:

```cs
bitField.FillField();
```

To set a flag, use:

```cs
bitField.SetOff(BitField.Flag.F1);       //Flag F1 off
bitField.SetOn(BitField.Flag.F1);        //Flag F1 on
bitField.SetToggle(BitField.Flag.F1);    //Flag F1 off
bitField.SetToggle(BitField.Flag.F1);    //Flag F1 on
```

To check if a Flag is on, use:

```cs
if (bitField.IsOn(BitField.Flag.f1)) {
  Console.WriteLine("Flag F1 is On");
}
```

## Points of Interest

The mask value is a 64-bit number that can be stored, retrieved, or passed to other processes and applications that support 64-bit numbers. The `BitField` class/structure can then be used to retrieve and manipulate the mask. I did not find any resources that explains how bitwise operations are implemented in .NET, and if the operations are implemented efficiently. There might be ways to optimize the code but I have not found a good resource for this yet.

It is also important to note that there is some overhead in creating a class object, as classes are reference types and structures are value types. If this is an issue then it is possible to implement the bit field operations directly in your code, but that would defeat the purpose of the object-oriented model.

Another option to consider is using a structure instead of the class.

A structure can be preferable when:

- You have a small amount of data less than 16-bytes, or 128-bits.
- You perform a large number of operations on each instance and would incur performance degradation with heap management.
- You have no need to inherit the structure or to specialize functionality among its instances.
- You do not box and unbox the structure.
- You are passing blittable data across a managed/unmanaged boundary. 

A class is preferable when:

- You need to use inheritance and polymorphism.
- You need to initialize one or more members at creation time.
- You need to supply an un-parameterized constructor.
- You need unlimited event handling support. 

A similar bit field class and bit field structure are included in the source code and demo project. Depending on the use, it might be preferable to use one over the other. It would be interesting to time them and compare actual results to see under which circumstances and how much more efficiently the system can handle the structure.
 
## Installation

This library can be installed from [NuGet].

## References

[BitFields], [Enums]

## Report An Issue

If you have a patch to contribute, a feature to request, or a bug to report, please post to the [Issue Tracker](https://github.com/Latency/BitField.Extensions/issues).

## Donation

Click the button to donate to my efforts:
[![Donate via Paypal](https://www.paypal.com/en_US/i/btn/btn_donateCC_LG.gif)](https://paypal.me/Latency2?country.x=US&locale.x=en_US)

## License

The source code for the site is licensed under the MIT license, which you can find in the [MIT-LICENSE].txt file.

---

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job.)

   [NuGet]: <https://github.com/Latency/BitField.Extensions/pkgs/nuget/BitField.Extensions/>
   [.NET]: <https://en.wikipedia.org/wiki/.NET_Framework/>
   [Visual Studio]: <https://en.wikipedia.org/wiki/Microsoft_Visual_Studio/>
   [Library]: <https://en.wikipedia.org/wiki/Software_library/>
   [Latency McLaughlin]: <https://www.linkedin.com/in/Latency/>
   [API]: <https://en.wikipedia.org/wiki/Application_programming_interface>
   [C#]: <https://en.wikipedia.org/wiki/C_Sharp_(programming_language)>
   [DLL]: <https://en.wikipedia.org/wiki/Dynamic-link_library>
   [MIT-License]: <http://choosealicense.com/licenses/mit/>
   [WPF]: <https://en.wikipedia.org/wiki/Windows_Presentation_Foundation/>
   [WinForms]: <https://en.wikipedia.org/wiki/Windows_Forms/>
   [Unit Tests]: <https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-csharp-with-xunit>
   [BitFields]: <https://en.wikipedia.org/wiki/Bit_field/>
   [Enums]: <https://en.wikipedia.org/wiki/Enumerated_type/>
