using System;
using NUnit.Framework;
using Spare.Deco;
using Veho.Vector;
using Veho.Matrix;
using Inits = Veho.Matrix.Inits;

namespace Spare.Test.DecoVector {
  [TestFixture]
  public class TestCollection {
    [Test]
    public void DecoVectorTest() {
      var elements = new[] {1, 2, 3};
      Console.WriteLine(elements.Deco());
      Assert.True(true);
    }
    [Test]
    public void DecoMatrixTest() {
      var elements = Inits.Init(3, 5, (i, j) => Math.Pow(10, i * 2 + 1) + (j + 1));
      Console.WriteLine(elements.Deco());
      Assert.True(true);
    }
    [Test]
    public void DecoMatrix1BTest() {
      var elements = Base1.M1B<int>(3, 5);
      Console.WriteLine(elements.Deco());
      Assert.True(true);
    }
  }
}