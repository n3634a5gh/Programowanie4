
using System.Data.SqlClient;
using Dapper;

var connectionString = @"Data Source=LAPTOP-IKCEP9LL\SQLEXPRESS;Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
using var conn = new SqlConnection(connectionString);

var newRegion = new Region()
{
    RegionID = 10,
    RegionDescription = "testregion2"
};

/*var insertResult = conn.Execute(
    "INSERT INTO Region(RegionID,RegionDescription) VALUES(@RegionID,@RegionDescription)",
newRegion);*/

var regions = conn.Query<Region>("SELECT * FROM REGION");

foreach (var item in regions)
{
    //Console.WriteLine($"{item.RegionID}: {item.RegionDescription}");
}


var joinResult = conn.Query<Product, Category, Product>(
    "SELECT * FROM Products p JOIN Categories c ON p.CategoryID=c.CategoryID",
    (product, category) =>
    {
        product.Category = category;
        return product;
    },
    splitOn:"CategoryID"
    );

foreach (var item in joinResult)
{
   // Console.WriteLine($"{item.ProductName}: {item.Category.CategoryName}");
}

var join2result = conn.Query<Territories, Region, Territories>(
    "SELECT * FROM Territories t JOIN Region r ON t.RegionID=r.RegionID " +
     "WHERE t.TerritoryDescription LIKE  CONCAT (@ltter,'%')" ,
    (territories,regions)=>
    {
        territories.Region = regions;
        return territories;
    },
    new {ltter="T"},
    splitOn:"RegionID"
    );

foreach(var item in join2result)
{
    Console.WriteLine($"{item.TerritoryDescription}:{item.Region.RegionDescription}");
}


