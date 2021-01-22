using System;
using NUnit.Framework;
using Spare.Deco;

namespace Spare.Test.DecoVector {
  [TestFixture]
  public class TestCollection {
    [Test]
    public void Test1() {
      var elements = new[] {1, 2, 3};
      Console.WriteLine(elements.DecoVector());
      Assert.True(true);
    }
  }
}