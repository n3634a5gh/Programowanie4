using System;
using System.Collections.Generic;

namespace Projekt1_Amortyzacja.Projekt_Amortyzacja
{
    public partial class Amortyzacja
    {
        public int IdAmortyzacji { get; set; }
        public int IdPlanu { get; set; }
        public decimal KwotaRozliczona { get; set; }
        public decimal WartoscRozliczenia { get; set; }
        public bool Zakonczona { get; set; }

        public virtual PlanAmortyzacji IdPlanuNavigation { get; set; } = null!;
    }
}
