namespace ORM_Dapper;

public interface IProductRepository
{
    IEnumerable<Products> GetAllProducts();
    
    
    void CreateProduct(string name, double price, int categoryID);
}
