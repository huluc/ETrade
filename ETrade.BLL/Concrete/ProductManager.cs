using ETrade.DAL.Abstract;
using ETrade.Entity.Concrete;
using ETrade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetByCategoryId(int id) // Ayrı metot yazılmasındaki amaç; farklı bir UI da böyle bir metoda ihtiyaç duyulursa bu kodları tekrarlamaktan ve bu query i düşünmekten kurtulmak.  
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
