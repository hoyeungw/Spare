using NUnit.Framework;
using Palett;
using Spare.Test.Resources;
using Veho;

namespace Spare.Test {
  [TestFixture]
  public partial class DecoesTests {
    [Test]
    public void DecoEntriesTestAlpha() {
      Candidates.CarPlants.DecoEntries().Logger();
    }

    [Test]
    public void DecoTriEntries() {
      var entries = Seq.From(
        ("foo", 1, true),
        ("bar", 6, false),
        ("zen", 4, false),
        ("kha", 2, true)
      );
      entries.DecoEntries(presets: (Presets.Jungle, Presets.Fresh)).Says("quadri entries");
    }

    [Test]
    public void DecoQuadriEntries() {
      var entries = Seq.From(
        ("foo", 1, 1, true),
        ("bar", 6, -1, false),
        ("zen", 4, 1, false),
        ("kha", 2, -1, true)
      );
      entries.DecoEntries(presets: (Presets.Jungle, Presets.Fresh)).Says("quadri entries");
    }
  }
}