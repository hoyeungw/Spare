using System;
using NUnit.Framework;
using Veho;
using Veho.Types;
using static Palett.Presets;

namespace Spare.Test {
  [TestFixture]
  public partial class DecoesTests {
    [Test]
    public void DecoMatrixTest() {
      var elements = Mat.Init(3, 5, (i, j) => Math.Pow(10, i * 2 + 1) + (j + 1));
      elements.Deco(orient: Operated.Rowwise, presets: (Metro, Planet)).Logger();
      elements.Deco().Logger();
      Assert.True(true);
    }
    // [Test]
    // public void DecoMatrix1BTest() {
    //   var elements = (3, 5).M1B<int>();
    //   elements.DecoM1B().Logger();
    //   Assert.True(true);
    // }
  }
}