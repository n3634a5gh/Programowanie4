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
    internal class Add_data
    {
        private static bool check_existing(int check_table,int identifier)
        {
            var context = new Projekt_AmortyzacjaContext();
            context.Database.EnsureCreated();
            context.Database.Migrate();

            switch (check_table)
            {
                case 1:
                    {
                        var result = context.Klasyfikacjas
                            .Where(Klasyfikacja => Klasyfikacja.IdKlasy==identifier)
                            .ToList();

                        if (result.Any())
                        {
                            return true;
                        }
                        else { return false; }

                        break;
                    }

                    case 2:
                    {
                        var result = context.Wytworcas
                            .Where(Wytworca => Wytworca.IdWytworcy == identifier)
                            .ToList();

                        if (result.Any())
                        {
                            return true;
                        }
                        else { return false; }

                        break;
                    }
            }

            return true;
        }

        private static void add_klasyfikacja()
        {
            var context = new Projekt_AmortyzacjaContext();
            context.Database.EnsureCreated();
            context.Database.Migrate();

            int grupa, podgrupa, rodzaj;
            float stawka;
            string opis = "";

            Console.WriteLine("Podaj numer grupy:");
            grupa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj numer podgrupy:");
            podgrupa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj rodzaj:");
            rodzaj = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj stawke amortyzacji:");
            stawka = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
            Console.WriteLine("Opis srodka:");
            opis = Console.ReadLine();

            var klasyfikacja = new Klasyfikacja()
            {
                NrGrupy = (short)grupa,
                NrPodgrupy = (short)podgrupa,
                Rodzaj = (short)rodzaj,
                StawkaAmortyzacji = stawka,
                Opis = opis
            };

            context.Klasyfikacjas.Add(klasyfikacja);
            context.SaveChanges();

        }

        private static void add_wytworca()
        {
            var context = new Projekt_AmortyzacjaContext();
            context.Database.EnsureCreated();
            context.Database.Migrate();

            string email, nazwa, nip, telefon, kraj, miejscowosc, ulica, numer;

            Console.WriteLine("Podaj nazwe firmy:");
            nazwa = Console.ReadLine();
            Console.WriteLine("Podaj email:");
            email = Console.ReadLine();
            Console.WriteLine("Podaj NIP:");
            nip = Console.ReadLine();
            Console.WriteLine("Podaj telefon:");
            telefon = Console.ReadLine();
            Console.WriteLine("Podaj kraj:");
            kraj = Console.ReadLine();
            Console.WriteLine("Podaj miejscowosc:");
            miejscowosc = Console.ReadLine();
            Console.WriteLine("Podaj ulice:");
            ulica = Console.ReadLine();
            Console.WriteLine("Podaj numer lokalu:");
            numer = Console.ReadLine();

            var wytworca = new Wytworca()
            {
                Nazwa = nazwa,
                Email = email,
                Nip = nip,
                Telefon = telefon,
                Kraj = kraj,
                Miejscowosc = miejscowosc,
                Ulica = ulica,
                NrLokalu = numer
            };

            context.Wytworcas.Add(wytworca);
            context.SaveChanges();
        }

        private static void add_srodek()
        {
            var context = new Projekt_AmortyzacjaContext();
            context.Database.EnsureCreated();
            context.Database.Migrate();

            string dataprzyjecia, datazakupu, lokalizacja, opis;
            int idwytworcy, idklasy,znak;
            decimal wartosc=0;


            Console.WriteLine("Podaj identyfikator wytworcy:");
            idwytworcy = Convert.ToInt32(Console.ReadLine());
            if (check_existing(2, idwytworcy) == false)
            {
                Console.WriteLine("Wytwórca o podanym ID nie istnieje.");
                Console.WriteLine("Czy chcesz utworzyc nowego wytworce ?  1/0.");

                znak = Convert.ToInt32(Console.ReadLine());

                if(znak==1)
                {
                    add_wytworca();
                    var result = context.Wytworcas
                    .ToList();

                    Console.WriteLine("Utworzono nowego wytworce z ID = " + result.Last().IdWytworcy);
                    idwytworcy = result.Last().IdWytworcy;
                }
                else
                {
                    while(check_existing(2, idwytworcy) == false)
                    {
                        Console.WriteLine("Podaj istniejace ID wytworcy");
                        idwytworcy = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            Console.WriteLine("Podaj identyfikator klasy:");
            idklasy = Convert.ToInt32(Console.ReadLine());
            if (check_existing(1, idklasy) == false)
            {
                Console.WriteLine("Klasa o podanym ID nie istnieje.");
                Console.WriteLine("Czy chcesz utworzyc nowa klase ?  1/0.");

                znak = Convert.ToInt32(Console.ReadLine());

                if (znak == 1)
                {
                    add_klasyfikacja();
                    var result = context.Klasyfikacjas
                    .ToList();

                    Console.WriteLine("Utworzono nowa klase z ID = " + result.Last().IdKlasy);
                    idklasy = result.Last().IdKlasy;
                }
                else
                {
                    while (check_existing(1, idklasy) == false)
                    {
                        Console.WriteLine("Podaj ID istniejacej klasy");
                        idwytworcy = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            Console.WriteLine("Podaj date zakupu(DD.MM.RR):");
            datazakupu = Console.ReadLine();
            Console.WriteLine("Podaj date przyjecia(DD.MM.RR):");
            dataprzyjecia = Console.ReadLine();
            Console.WriteLine("Podaj lokalizacje srodka:");
            lokalizacja = Console.ReadLine();
            Console.WriteLine("Podaj opis srodka");
            opis = Console.ReadLine();
            Console.WriteLine("Podaj wartosc srodka");
            wartosc=Convert.ToDecimal(Console.ReadLine());

            var srodektrwaly = new SrodekTrwaly()
            {
                IdKlasy = idklasy,
                IdWytworcy = idwytworcy,
                DataPrzyjecia = Convert.ToDateTime(dataprzyjecia),
                DataZakupu = Convert.ToDateTime(datazakupu),
                Lokalizacja = lokalizacja,
                Aktywny = true,
                Amortyzowalny = true,
                Opis = opis
            };

            srodektrwaly.WartoscSrodkaTrwalegos.Add(new WartoscSrodkaTrwalego()
            {
                Wartosc = wartosc,
                DataAktualizacji=DateTime.Now
            });

            context.SrodekTrwalies.Add(srodektrwaly);
            context.SaveChanges();
        }

        public void data_add(int wybor)
        {
            switch (wybor)
            {
                case 1:
                    {
                        add_klasyfikacja();
                        break;
                    }
                    case 2:
                    {
                        add_wytworca();
                        break;
                    }
                case 3:
                    {
                        add_srodek();
                        break;
                    }
            }
        }
    }
}
