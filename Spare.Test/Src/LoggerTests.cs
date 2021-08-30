using NUnit.Framework;
using Spare.Test.Resources;
using Texting.Enums;

namespace Spare.Test {
  [TestFixture]
  public class LoggerTests {
    [Test]
    public void Test() {
      123.Logger(1, 2, 3);
      "Now is the winter of our discontent, made glorious by the sun or York.".Says("Richard III", Strings.LF);
      "To be or not to be, that is a question\n".Says("Hamlet", Strings.LF);
      Candidates.CarPlants.DecoEntries().Says("CarPlants");
    }
  }
}