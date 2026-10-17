// ****************************************************************************
// Project:  BitField.Extensions
// File:     IToString.cs
// Author:   Latency McLaughlin
// Date:     10/16/2026
// ****************************************************************************

namespace BitField.Extensions;

// ///////////////////////////////////////////////////////////////////////////////
// ToString override | Union 3-ways
// ///////////////////////////////////////////////////////////////////////////////
public interface IToString
{
    string Decimal();
    string Hex();
    string Binary();
}