using Microsoft.EntityFrameworkCore;
using zad41;

var context = new MyDbContext();
context.Database.EnsureCreated();


 static string RandomString(int range)
{
    var chars = "abcdefghijklmnopqrstuwxyz";
    var random = new Random();
    var result = new string(
        Enumerable.Repeat(chars, range)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());

    char[] resultAsChars = result.ToCharArray();
    resultAsChars[0]=char.ToUpper(resultAsChars[0]);
   result = new string(resultAsChars);

    return result;
}

Random rnd = new Random();



for (int j = 0; j < 15; j++)
{
    var author = new Author()
    {
        Name = RandomString(rnd.Next(3, 8)),
        LastName = RandomString(rnd.Next(5, 10))
    };

    for (int i = 0; i < 4; i++)
    {
        author.Books.Add(new Book()
        {
            Title = (RandomString(rnd.Next(5, 15)) + " " + RandomString(rnd.Next(5, 15))),
            Year = rnd.Next(1950, 2022)
        });
    }


    context.Authors.Add(author);

    context.SaveChanges();
}

Console.WriteLine("Opcje wyszukiwania: ");
Console.WriteLine("1. Wyszukaj autora po nazwisk u");
Console.WriteLine("2. Wyszukaj ksiązkę po tytule ");
Console.WriteLine("3. Wyszukaj książkę według autora ");

int wybor = 0;
string datafromuser;

wybor=Convert.ToInt16(Console.ReadLine());
Console.Clear();
switch(wybor)
{
    case 1:
        {
            Console.WriteLine("Podaj nazwisko autora:");
            datafromuser =Console.ReadLine();
            foreach (var item in context.Authors.ToList())
            {
               if(item.LastName==datafromuser)
                Console.WriteLine("\nAutor: "+item.Name+" "+item.LastName);
            }

            break;
        }
    case 2:
        {
            Console.WriteLine("Podaj tytul ksiazki:");
            datafromuser = Console.ReadLine();
            foreach (var item in context.Books.ToList())
            {
                if (item.Title == datafromuser)
                    Console.WriteLine("\nKsiazka: " + item.Title + "\n" +
                        "Rok wydania: "+ item.Year);
            }
            break;
        }
    case 3:
        {
            int author_index=0;
            Console.WriteLine("Podaj nazwisko autora:");
            datafromuser = Console.ReadLine();
            foreach (var item in context.Authors.Include(x => x.Books).ToList())
            {
                if (item.LastName == datafromuser)
                {
                    Console.WriteLine("\nAutor: " + item.Name + " " + item.LastName+"\n");
                    author_index = item.Id;
                }
                    
            }
            foreach (var item in context.Books.ToList())
            {
                if (item.AuthorID == author_index)
                    Console.WriteLine("\nTytuł: " + item.Title + "\n" +
                        "Rok wydania: " + item.Year);
            }

            break;
//.
        }
}




