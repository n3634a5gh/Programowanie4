using System;
using System.Data.SqlClient;


namespace zad2
{
    class Program
    {
        static void Main()
        {
            var name="";
            int supplierID=0;
            int categoryID = 0; ;
            float price=0;
            int units_in_stock=0;

            SqlConnection bd1;
            string connectionString = @"Data Source=LAPTOP-IKCEP9LL\SQLEXPRESS;Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            bd1 = new SqlConnection(connectionString);
            bd1.Open();

            //var cmd = new SqlCommand("SELECT * FROM REGION where RegionId>@id", bd1);

            /*var cmd=new SqlCommand("INSERT INTO DBO.Products(ProductName,SupplierID,CategoryID,UnitPrice,UnitsInStock,Discontinued)" +
                "VALUES(@ProductName,@SupplierID,@CategoryID,@Price,@in_stock,0)", bd1);*/

            Console.WriteLine("Nazwa produktu: ");
            name = Console.ReadLine();
            Console.WriteLine("ID Dostawcy: ");
            supplierID=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ID Kategorii: ");
            categoryID=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cena: ");
            price = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("W magazynie: ");
            units_in_stock = Convert.ToInt32(Console.ReadLine());

            var cmd = new SqlCommand("INSERT INTO DBO.Products(ProductName,SupplierID,CategoryID,UnitPrice,UnitsInStock,Discontinued)" +
                "VALUES(@ProductName,@SupplierID,@CategoryID,@Price,@in_stock,0)", bd1);

            cmd.Parameters.Add("@ProductName",System.Data.SqlDbType.VarChar,50).Value=name;
            cmd.Parameters.Add("@SupplierID", System.Data.SqlDbType.Int).Value = supplierID;
            cmd.Parameters.Add("@CategoryID", System.Data.SqlDbType.Int).Value = categoryID;
            cmd.Parameters.Add("@Price", System.Data.SqlDbType.Money).Value=price;
            cmd.Parameters.Add("@in_stock",System.Data.SqlDbType.Int).Value=units_in_stock;


            /*var reader=cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]}: {reader[1]}");
            }

            reader.Close(); */


            cmd.ExecuteNonQuery();
            bd1.Close();
            
        }
    }
}

