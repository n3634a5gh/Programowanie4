using System;
using System.Collections.Generic;

namespace Projekt1_Amortyzacja.Projekt_Amortyzacja
{
    public partial class WartoscSrodkaTrwalego
    {
        public WartoscSrodkaTrwalego()
        {
            PlanAmortyzacjis = new HashSet<PlanAmortyzacji>();
        }

        public int IdWartosci { get; set; }
        public int NrSrodkaTrwalego { get; set; }
        public decimal Wartosc { get; set; }
        public DateTime DataAktualizacji { get; set; }

        public virtual SrodekTrwaly NrSrodkaTrwalegoNavigation { get; set; } = null!;
        public virtual ICollection<PlanAmortyzacji> PlanAmortyzacjis { get; set; }
    }
}
