using System;
using System.Collections.Generic;

namespace Projekt1_Amortyzacja.Projekt_Amortyzacja
{
    public partial class PlanAmortyzacji
    {
        public PlanAmortyzacji()
        {
            Amortyzacjas = new HashSet<Amortyzacja>();
        }

        public int IdPlanu { get; set; }
        public int IdWartosci { get; set; }
        public decimal WartoscAmortyzacji { get; set; }
        public DateTime DataWprowadzenia { get; set; }

        public virtual WartoscSrodkaTrwalego IdWartosciNavigation { get; set; } = null!;
        public virtual ICollection<Amortyzacja> Amortyzacjas { get; set; }
    }
}
