using System;
using NUnit.Framework;
using Spare.Deco;

namespace Spare.Test.DecoVector {
  [TestFixture]
  public class TestCollection {
    [Test]
    public void DecoVectorTest() {
      var elements = new[] {1, 2, 3};
      Console.WriteLine(elements.Deco());
      Assert.True(true);
    }
  }
}