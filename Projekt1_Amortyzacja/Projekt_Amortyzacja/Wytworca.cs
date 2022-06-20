using System;
using System.Collections.Generic;

namespace Projekt1_Amortyzacja.Projekt_Amortyzacja
{
    public partial class Wytworca
    {
        public Wytworca()
        {
            SrodekTrwalies = new HashSet<SrodekTrwaly>();
        }

        public int IdWytworcy { get; set; }
        public string Nazwa { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Nip { get; set; }
        public string? Telefon { get; set; }
        public string? Kraj { get; set; }
        public string? Miejscowosc { get; set; }
        public string? Ulica { get; set; }
        public string? NrLokalu { get; set; }

        public virtual ICollection<SrodekTrwaly> SrodekTrwalies { get; set; }
    }
}
