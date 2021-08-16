﻿using System.Collections.Generic;
using Veho;

namespace Spare.Test.DecoVector {
  public static class Candidates {
    public static List<(string key, string value)> CarPlants => Li.From(
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