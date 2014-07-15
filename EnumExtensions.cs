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
    public static IEnumerable<T> GetAllItems<T>(this Enum value) {
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
    /// <returns></returns>
    /// <example>
    ///   Displays ValueA and ValueB.
    ///   <code>
    ///     EnumExample dummy = EnumExample.Combi;
    ///     foreach (var item in dummy.GetAllSelectedItems<EnumExample>())
    ///       Console.WriteLine(item);
    ///   </code>
    /// </example>
    public static IEnumerable<T> GetAllSelectedItems<T>(this Enum value) {
      var valueAsInt = Convert.ToUInt64(value, CultureInfo.InvariantCulture);
      return GetAllSelectedItems<T>(valueAsInt);
    }

    public static IEnumerable<T> GetAllSelectedItems<T>(ulong value) {
      return from object item in Enum.GetValues(typeof (T)) let itemAsInt = Convert.ToUInt64(item, CultureInfo.InvariantCulture) where itemAsInt == (value & itemAsInt) select (T) item;
    }

    /// <summary>
    ///   Determines whether the enum value contains a specific value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="request">The request.</param>
    /// <returns>
    ///   <c>true</c> if value contains the specified value; otherwise, <c>false</c>.
    /// </returns>
    /// <example>
    ///   <code>
    ///     EnumExample dummy = EnumExample.Combi;
    ///     if (dummy.Contains<EnumExample>(EnumExample.ValueA))
    ///       Console.WriteLine("dummy contains EnumExample.ValueA");
    ///   </code>
    /// </example>
    public static bool Contains<T>(this Enum value, T request) {
      var valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);
      var requestAsInt = Convert.ToInt32(request, CultureInfo.InvariantCulture);
      return requestAsInt == (valueAsInt & requestAsInt);
    }

    /// <summary>
    ///   Gets the enums description attribute name.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>A string of the official spelling of the enum name.</returns>
    public static string GetEnumDescription(this Enum value) {
      var fi = value.GetType().GetField(value.ToString());
      var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
      return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
  }
}