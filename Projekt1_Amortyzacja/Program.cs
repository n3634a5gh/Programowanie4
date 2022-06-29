using Microsoft.EntityFrameworkCore;
using Projekt1_Amortyzacja;
using Projekt1_Amortyzacja.Projekt_Amortyzacja;


var context = new Projekt_AmortyzacjaContext();
context.Database.EnsureCreated();
context.Database.Migrate();

while(true)
{
    int program = 0;
    var dataadd = new Add_data();
    var datashow = new Data_show();
    Console.Clear();

    Console.WriteLine("Amortyzacja srodkow trwalych\n\n");
    Console.WriteLine("1.Dodawanie nowej klasyfikacji:");
    Console.WriteLine("2.Dodawanie nowego wytworcy:");
    Console.WriteLine("3.Dodawanie nowego srodka trwalego:");
    Console.WriteLine("4.Wyswietl dane o srodku trwalym:");
    Console.WriteLine("0.Wyjscie");

    program=Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    if (program == 0)
        break;

    if(program!=4)
    {
        dataadd.data_add(program);
    }
    else
    {
        datashow.data_show();
        System.Console.ReadKey();
    }
    

}
