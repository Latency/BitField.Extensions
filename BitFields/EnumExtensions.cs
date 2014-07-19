// ****************************************************************************
// * Project:  BitFields
// * File:     EnumExtensions.cs
// * Author:   Latency McLaughlin
// * Date:     07/15/2014
// ****************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;


namespace BitFields {
  public static class EnumExtensions {
    /// <summary>
    ///   Gets all items for an enum value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    public static IEnumerable<T> GetAllItems<T>(this Enum value) where T : struct, IComparable, IFormattable, IConvertible {
      return from object item in Enum.GetValues(typeof (T)) select (T) item;
    }

    /// <summary>
    ///   Gets all items for an enum type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static IEnumerable<T> GetAllItems<T>() where T : struct, IComparable, IFormattable, IConvertible {
      return Enum.GetValues(typeof (T)).Cast<T>();
    }

    /// <summary>
    ///   Gets all combined items from an enum value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <returns>A collection of enums</returns>
    public static IEnumerable<T> GetAllSelectedItems<T>(this Enum value) where T : struct, IComparable, IFormattable, IConvertible {
      var valueAsInt = Convert.ToUInt64(value, CultureInfo.InvariantCulture);
      return GetAllSelectedItems<T>(valueAsInt);
    }

    // Compare All
    public static IEnumerable<T> GetAllSelectedItems<T>(ulong value) where T : struct, IComparable, IFormattable, IConvertible {
      for (var idx = 0; idx < 64; idx++) {
        var flag = (Flag) Enum.Parse(typeof (Flag), "F" + (idx + 1));
        if (Contains(value, flag))
          yield return (T) Enum.Parse(typeof(T), flag.ToString());
      }
    }

    /// <summary>
    ///   Determines whether the enum value contains a specific value.
    /// </summary>
    /// <param name="mask">The mask</param>
    /// <param name="value">The value</param>
    /// <returns>
    ///   <c>true</c> if value contains the specified value; otherwise, <c>false</c>.
    /// </returns>
    /// <example>
    ///   <code>
    ///     EnumExample dummy = EnumExample.Combi;
    ///     if (dummy.Contains(EnumExample.ValueA))
    ///       Console.WriteLine("dummy contains EnumExample.ValueA");
    ///   </code>
    /// </example>
    public static bool Contains<T>(this Enum mask, T value) where T : struct, IComparable, IFormattable, IConvertible {
      return Contains(Convert.ToUInt64(mask), value);
    }

    // Contains Any
    public static bool Contains<T>(ulong mask, T value) where T : struct, IComparable, IFormattable, IConvertible {
      return new BitField(mask).IsSet((Flag)Enum.ToObject(typeof(T), value), true);
    }

    /// <summary>
    ///   Gets the enums description attribute name.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>A string of the official spelling of the enum name.</returns>
    public static string GetEnumDescription(this Enum value) {
      var attributes = (DescriptionAttribute[]) value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
      return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
  }
}