using System.Collections.Generic;
using Veho;

namespace Spare.Test.Resources {
  public static class Candidates {
    public static List<(string key, string value)> CarPlants => Seq.From(
      ("SantAgata", "Lamborghini"),
      ("Angelholm", "Koenigsegg"),
      ("Molsheim", "Bugatti"),
      ("Gaydon", "Aston Martin"),
      ("Maranello", "Ferrari"),
      ("Stuttgart", "Porsche"),
      ("Modena", "Pagani"),
      ("Neckarsulm", "Audi"),
      ("Crewe", "Bentley"),
      ("Woking", "McLaren"),
      ("Hethel", "Lotus")
    );
  }
}