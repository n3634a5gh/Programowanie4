using Microsoft.EntityFrameworkCore;
using Projekt1_Amortyzacja;
using Projekt1_Amortyzacja.Projekt_Amortyzacja;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Projekt1_Amortyzacja
{
    internal class Data_show
    {
        public void data_show()
        {
            var context = new Projekt_AmortyzacjaContext();
            string danapodana="";

            Console.WriteLine("Podaj nazwe srodka trwalego:");
            danapodana = Convert.ToString(Console.ReadLine());

            var result = context.Klasyfikacjas
                .Include(a => a.SrodekTrwalies)
                .ThenInclude(b => b.WartoscSrodkaTrwalegos)
                .Where(a => a.SrodekTrwalies.First().Opis==danapodana)
                .ToArray();

            foreach(var item in result)
            {
                Console.WriteLine("Srodek trwaly: " + item.SrodekTrwalies.First().Opis);
                Console.WriteLine("Opis klasy: " + item.Opis);
                Console.WriteLine("DataZakupu: " + item.SrodekTrwalies.First().DataZakupu);
                Console.WriteLine("DataPrzyjecia: " + item.SrodekTrwalies.First().DataPrzyjecia);
                Console.WriteLine("Wartosc srodka: "+item.SrodekTrwalies.First().WartoscSrodkaTrwalegos.First().Wartosc);
                Console.WriteLine("\n");
            }
        }
    }
}
