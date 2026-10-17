// ****************************************************************************
// Project:  Unit Tests
// File:     eTest.cs
// Author:   Latency McLaughlin
// Date:     10/16/2026
// ****************************************************************************

namespace Unit_Tests.Enums;

/// <summary>
///     Create dummy enum to test against internal mapping of values and descriptions accordingly.
/// </summary>
[Flags]
internal enum MyEnum
{
    Test0 = 1 << 0,
    Test1 = 1 << 1,
    Test2 = 1 << 2,
    Test3 = 1 << 3,
    Test4 = 1 << 4,
    Test5 = 1 << 5
}