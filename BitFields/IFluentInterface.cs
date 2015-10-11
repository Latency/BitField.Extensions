// *****************************************************************************
// File:      IFluentInterface.cs
// Solution:  BitFields
// Date:      10/10/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.ComponentModel;

namespace BitFields {
  /// <summary>
  ///   Interface that is used to build fluent interfaces and hides methods declared by <see cref="object" /> from
  ///   IntelliSense.
  /// </summary>
  /// <remarks>
  ///   Code that consumes implementations of this interface should expect one of two things:
  ///   <list type="number">
  ///     <item>
  ///       When referencing the interface from within the same solution (project reference), you will still see the
  ///       methods this interface is meant to hide.
  ///     </item>
  ///     <item>
  ///       When referencing the interface through the compiled output assembly (external reference), the standard Object
  ///       methods will be hidden as intended.
  ///     </item>
  ///   </list>
  ///   See http://clarius.to/IFluentInterface for more information.
  /// </remarks>
  /// <nuget id="IFluentInterface" />
  [EditorBrowsable(EditorBrowsableState.Never)]
  public interface IFluentInterface {
    /// <summary>
    ///   Redeclaration that hides the <see cref="object.GetType()" /> method from IntelliSense.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    Type GetType();

    /// <summary>
    ///   Redeclaration that hides the <see cref="object.GetHashCode()" /> method from IntelliSense.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    int GetHashCode();

    /// <summary>
    ///   Redeclaration that hides the <see cref="object.ToString()" /> method from IntelliSense.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    string ToString();

    /// <summary>
    ///   Redeclaration that hides the <see cref="object.Equals(object)" /> method from IntelliSense.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    bool Equals(object obj);
  }
}