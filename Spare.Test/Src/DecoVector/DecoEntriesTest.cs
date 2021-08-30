using NUnit.Framework;
using Spare.Test.Resources;

namespace Spare.Test.DecoVector {
  [TestFixture]
  public class DecoEntriesTest {
    [Test]
    public void DecoEntriesTestAlpha() {
      Candidates.CarPlants.DecoEntries().Logger();
    }
  }
}