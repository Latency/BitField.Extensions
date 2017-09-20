//  *****************************************************************************
//  File:       T_EnumExtensions.cs
//  Solution:   BitFields
//  Project:    BitFields Tests
//  Date:       09/05/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Linq;
using BitFields;
using NUnit.Framework;

namespace BitFields_Tests {
  // ReSharper disable once InconsistentNaming
  public class T_EnumExtensions {
    [Test]
    public void GetAllItems() {
      var collectionA = Flag.F1.GetAllItems<Flag>().ToList();
      Assert.AreEqual(65, collectionA.Count);

      var collectionB = EnumExtensions.GetAllItems<Flag>().ToList();
      Assert.AreEqual(65, collectionB.Count);

#if DEBUG
      foreach (var enm in collectionB)
        Console.WriteLine(enm.GetEnumDescription());
#endif
    }

    [Test]
    public void GetAllSelectedItems() {
      // If enum is not bitvectored, this will compose (1 | 4)
      var collectionA = MyEnum.Test5.GetAllSelectedItems<MyEnum>().ToList();
      Assert.AreEqual(1, collectionA.Count);
#if DEBUG
      Console.WriteLine("Test ColectionA:  Single");
      foreach (var enm in collectionA)
        Console.WriteLine(enm.GetEnumDescription());
#endif

      var collectionB = (MyEnum.Test4 | MyEnum.Test3).GetAllSelectedItems<MyEnum>().ToList();
      Assert.AreEqual(2, collectionB.Count);
#if DEBUG
      Console.WriteLine("Test ColectionB:  Composite");
      foreach (var enm in collectionB)
        Console.WriteLine(enm.GetEnumDescription());
#endif
      // Make sure the field (0) is not being transposed from internal ordered mapping.
      var collectionC = MyEnum.Test0.GetAllSelectedItems<MyEnum>().ToList();
      Assert.AreEqual(1, collectionC.Count);
#if DEBUG
      Console.WriteLine("Test ColectionC:  Single");
      foreach (var enm in collectionC)
        Console.WriteLine(enm.GetEnumDescription());
#endif

      // Check 1 + 2 = 3 field to see if it is being counted as single.
      var collectionD = (MyEnum.Test1 | MyEnum.Test0).GetAllSelectedItems<MyEnum>().ToList();
      Assert.AreEqual(2, collectionD.Count);
#if DEBUG
      Console.WriteLine("Test ColectionD:  Composite");
      foreach (var enm in collectionD)
        Console.WriteLine(enm.GetEnumDescription());
#endif

      // Test overloaded method w/ mask as input.  (Test1 | Test0)
      var collectionE = EnumExtensions.GetAllSelectedItems<MyEnum>(3).ToList();
      Assert.AreEqual(2, collectionE.Count);
#if DEBUG
      Console.WriteLine("Test ColectionE:  Value->Mapped");
      foreach (var enm in collectionE)
        Console.WriteLine(enm.GetEnumDescription());
#endif
    }

    [Test]
    public void Contains() {
      Assert.IsFalse(MyEnum.Test1.Contains(MyEnum.Test0));
      Assert.IsTrue(MyEnum.Test3.Contains(MyEnum.Test3));
      Assert.IsTrue(EnumExtensions.Contains(5UL, MyEnum.Test0 | MyEnum.Test2));
      Assert.IsTrue(EnumExtensions.Contains(5UL, MyEnum.Test0));
      Assert.IsFalse(EnumExtensions.Contains(5UL, MyEnum.Test1));
    }

    [Test]
    public void GetEnumDescription() {
      Assert.AreEqual("Test1", MyEnum.Test1.GetEnumDescription());
    }

    /// <summary>
    ///   Create dummy enum to test against internal mapping of values and descriptions accordingly.
    /// </summary>
    [Flags]
    private enum MyEnum {
      Test0 = 1 << 0,
      Test1 = 1 << 1,
      Test2 = 1 << 2,
      Test3 = 1 << 3,
      Test4 = 1 << 4,
      Test5 = 1 << 5
    }
  }
}