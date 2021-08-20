using NUnit.Framework;
using Texting.Enums;

namespace Spare.Test.DecoVector {
  [TestFixture]
  public class LoggerTests {
    [Test]
    public void Test() {
      123.Logger(1, 2, 3);
      "Now is the winter of our discontent, made glorious by the sun or York.".Says("Richard III", Strings.LF);
      "To be or not to be, that is a question".Says("Hamlet", Strings.LF);
    }
  }
}