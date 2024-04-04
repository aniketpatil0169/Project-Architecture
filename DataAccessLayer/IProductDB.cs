using Models;

namespace DataAccessLayer
{
    public interface IProductDB
    {
        bool CreateProduct(Product product);
    }
}
