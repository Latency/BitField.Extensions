// *****************************************************************************
// File:      IToString.cs
// Solution:  BitFields
// Date:      10/10/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

namespace BitFields {
  // ///////////////////////////////////////////////////////////////////////////////
  // ToString override | Union 3-ways
  // ///////////////////////////////////////////////////////////////////////////////
  public interface IToString : IFluentInterface {
    string Decimal();
    string Hex();
    string Binary();
  }
}