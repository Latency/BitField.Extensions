// ****************************************************************************
// Project:  BtFields
// File:     IToString.cs
// Author:   Latency McLaughlin
// Date:     01/09/2021
// ****************************************************************************

namespace BitFields {
    // ///////////////////////////////////////////////////////////////////////////////
    // ToString override | Union 3-ways
    // ///////////////////////////////////////////////////////////////////////////////
    public interface IToString {
        string Decimal();
        string Hex();
        string Binary();
    }
}