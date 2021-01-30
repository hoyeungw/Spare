using NUnit.Framework;
using Spare.Logger;

namespace Spare.Test.DecoVector {
  [TestFixture]
  public class LoggerTests {
    [Test]
    public void Test() {
      123.Logger(1, 2, 3);
    }
  }
}