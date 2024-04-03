using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class ProductBL : IproductBL
    {
        IProductDB _db;

        public ProductBL(IProductDB db)
        {
            _db = db;
        }

        public bool CreateProduct(Product product)
        {
            return _db.CreateProduct(product);
        }
    }
}
