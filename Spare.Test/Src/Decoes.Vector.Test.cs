using NUnit.Framework;
using static Palett.Presets;

namespace Spare.Test {
  [TestFixture]
  public partial class DecoesTests {
    [Test]
    public void DecoVectorTest() {
      var elements = new[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };
      elements.Deco(presets: (Metro, Planet)).Logger();
      // Assert.Pass(true);
    }
  }
}