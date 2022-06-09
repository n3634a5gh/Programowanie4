using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zad41;

namespace zad41
{
    public class Data_add
    {
        public Data_add()
        {
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
                resultAsChars[0] = char.ToUpper(resultAsChars[0]);
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

        }
    }
}
