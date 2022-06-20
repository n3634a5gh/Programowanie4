using System;
using System.Collections.Generic;

namespace Projekt1_Amortyzacja.Projekt_Amortyzacja
{
    public partial class Klasyfikacja
    {
        public Klasyfikacja()
        {
            SrodekTrwalies = new HashSet<SrodekTrwaly>();
        }

        public int IdKlasy { get; set; }
        public short NrGrupy { get; set; }
        public short NrPodgrupy { get; set; }
        public short Rodzaj { get; set; }
        public float StawkaAmortyzacji { get; set; }
        public string Opis { get; set; } = null!;

        public virtual ICollection<SrodekTrwaly> SrodekTrwalies { get; set; }
    }
}
