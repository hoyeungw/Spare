using NUnit.Framework;
using Veho;

namespace Spare.Test {
  [TestFixture]
  public class TupleTests {
    [Test]
    public void TestAlpha() {
      var tuple = (0, 0, 0);
      tuple.Item2 = 1;
      tuple.ToList().Deco().Logger();
    }
  }
}