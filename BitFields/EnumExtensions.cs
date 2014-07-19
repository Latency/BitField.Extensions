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
    public static IEnumerable<T> GetAllItems<T>(this Enum value) where T : struct {
      return from object item in Enum.GetValues(typeof (T)) select (T) item;
    }

    /// <summary>
    ///   Gets all items for an enum type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static IEnumerable<T> GetAllItems<T>() where T : struct {
      return Enum.GetValues(typeof (T)).Cast<T>();
    }

    /// <summary>
    ///   Gets all combined items from an enum value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <returns>A collection of enums</returns>
    public static IEnumerable<T> GetAllSelectedItems<T>(this Enum value) where T : struct {
      var valueAsInt = Convert.ToUInt64(value, CultureInfo.InvariantCulture);
      return GetAllSelectedItems<T>(valueAsInt);
    }

    // Compare All
    public static IEnumerable<T> GetAllSelectedItems<T>(ulong value) where T : struct {
      var bitfield = new BitField(value);
      for (var idx = 0; idx < 64; idx++) {
        var flag = (Flag) Enum.Parse(typeof (Flag), "F" + (idx + 1));
        if (bitfield.IsSet(flag, true))
          yield return (T) Enum.Parse(typeof(T), ((uint) flag).ToString(CultureInfo.InvariantCulture));
      }
    }

    /// <summary>
    ///   Determines whether the enum value contains a specific value.
    /// </summary>
    /// <param name="mask">The value.</param>
    /// <param name="request">The request.</param>
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
    public static bool Contains<T>(this Enum mask, T request) where T : struct {
      return Contains(Convert.ToUInt64(mask, CultureInfo.InvariantCulture), request);
    }

    // Contains Any
    public static bool Contains<T>(ulong value, T request) where T : struct {
      return new BitField(value).IsSet((Flag) Convert.ToUInt64(request, CultureInfo.InvariantCulture), true);
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