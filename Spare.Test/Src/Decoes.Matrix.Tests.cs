using NUnit.Framework;
using Veho;
using static System.Math;
using static Texting.Enums.Strings;

namespace Spare.Test {
  [TestFixture]
  public partial class DecoesTests {
    public static (string, double[,])[] Basics = {
                                                   ("alpha", Mat.Boot(Cos(PI / 3))),
                                                   ("alpha", Mat.Init(3, 5, (i, j) => Pow(10, i * 2 + 1) + (j + 1)))
                                                 };
    [Test]
    public void DecoMatrixTest() {
      foreach (var (key, matrix) in Basics) {
        key.Logger();
        matrix.Deco().Logger();
      }
    }

    [Test]
    public void DecoFlatTest() {
      foreach (var (key, matrix) in Basics) {
        key.Logger();
        matrix.DecoFlat(COLF, COSP).Logger();
      }
    }
  }
}