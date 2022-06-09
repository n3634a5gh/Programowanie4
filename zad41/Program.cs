using Microsoft.EntityFrameworkCore;
using zad41;

var context = new MyDbContext();

//var data=new Data_add();      //dodawanie klientów do bazy


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

            var result = context.Authors
            .Where(Author => Author.LastName == datafromuser)
            .ToArray();

            foreach (var item in result)
            {
                Console.WriteLine("\nAutor: "+item.Name+" "+item.LastName);
            }

            break;
        }
    case 2:
        {
            Console.WriteLine("Podaj tytul ksiazki:");
            datafromuser = Console.ReadLine();

            var result = context.Books
            .Where(Book => Book.Title == datafromuser)
            .ToArray();

            foreach (var item in result)
            {
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

            /*var result = context.Authors
                .Where(Author => Author.LastName == datafromuser)
                .Include(a=>a.Name)
                .ThenInclude(b => b.)
                .ToArray();*/

            /*var result = context.Authors
                .Join
                (
                context.Books,
                Author => Author.LastName,
                Book => Book.Author.Id,
                (Author, Book) => new
                {
                    Name = Author.Name,
                    LastName = Author.LastName,
                    Title = Book.Title,
                    Year = Book.Year
                })
                .ToArray();*/

            /* var query = from Author in context.Set<Author>()
                         join book in context.Set<Book>()
                         on new { Id=(int?)Author.Id,Author.LastName}
                         equals new {Id =book.AuthorID, LastName=datafromuser}
                         select new {Author, book};

                         /*on book.AuthorID equals Author.Id
                         select new { book, Author };*/



            var result = context.Authors
            .Where(Author => Author.LastName == datafromuser)
            .ToArray();

            foreach (var item in result)
            {
                Console.WriteLine("\nAutor: " + item.Name + " " + item.LastName);

                author_index = item.Id;
            }

            var result2 = context.Books
            .Where(Book => Book.AuthorID == author_index)
            .ToArray();

            foreach (var item in result2)
            {
                Console.WriteLine("\nTytuł: " + item.Title + " " + item.Year);

                author_index = item.Id;
            }



            /* foreach (var item in context.Authors.Include(x => x.Booksx).ToList())
            {
                if (item.LastName == datafromuser)
                {
                    Console.WriteLine("\nAutor: " + item.Name + " " + item.LastName+"\n");
                    author_index = item.Id;
                }

            }*/

            /*var query = from b in context.Set<Book>()
                        join a in context.Set<Author>()
                            on b.AuthorID equals a.Id into grouping
                        select new { b, Posts = grouping.Where(b => b.LastName.Contains(datafromuser)).ToArray()};

            foreach (var item in query)
            {
                Console.WriteLine(item.b.Title);
                Console.WriteLine(item.b.Year);
                Console.WriteLine(item.b.Author.Name);
                Console.WriteLine(item.b.Author.LastName); 
            }*/


            break;
//.
        }
}




