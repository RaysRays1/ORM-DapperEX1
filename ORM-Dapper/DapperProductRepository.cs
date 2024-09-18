using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public DapperProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    
    public IEnumerable<Products> GetAllProducts()
    {
        return _connection.Query<Products>("SELECT * FROM PRODUCTS;");
    }
    
    
    public void CreateProduct(string name, double price, int categoryID)
    {
        _connection.Execute("INSERT INTO Products (name, price, cateoryID) VALUES (@name, @price, @categortID);" +
                            new { name = name, price = price, categoryID = categoryID });
    }
}