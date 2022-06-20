using System;
using System.Collections.Generic;

namespace Projekt1_Amortyzacja.Projekt_Amortyzacja
{
    public partial class SrodekTrwaly
    {
        public SrodekTrwaly()
        {
            WartoscSrodkaTrwalegos = new HashSet<WartoscSrodkaTrwalego>();
        }

        public int NrSrodkaTrwalego { get; set; }
        public int IdKlasy { get; set; }
        public int? IdWytworcy { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime DataZakupu { get; set; }
        public string? Lokalizacja { get; set; }
        public bool Aktywny { get; set; }
        public bool Amortyzowalny { get; set; }
        public string? Opis { get; set; }

        public virtual Klasyfikacja IdKlasyNavigation { get; set; } = null!;
        public virtual Wytworca? IdWytworcyNavigation { get; set; }
        public virtual ICollection<WartoscSrodkaTrwalego> WartoscSrodkaTrwalegos { get; set; }
    }
}
