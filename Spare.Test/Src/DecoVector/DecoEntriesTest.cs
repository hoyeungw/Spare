using NUnit.Framework;

namespace Spare.Test.DecoVector {
  [TestFixture]
  public class DecoEntriesTest {
    [Test]
    public void DecoEntriesTestAlpha() {
      Candidates.CarPlants.ToArray().DecoEntries().Logger();
    }
  }
}