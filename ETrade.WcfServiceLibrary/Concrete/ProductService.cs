using ETrade.BLL.Concrete;
using ETrade.DAL.Concrete.EntityFramework;
using ETrade.Entity.Concrete;
using ETrade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.WcfServiceLibrary.Concrete
{
    //Bu sınıf IISHosta refere edilmeli.
    //SOAP standartına göre servis uygulamalarında constructor bloğu olmaz.
    public class ProductService : IProductService
    {
        //Bu kullanım new leme olduğundan yanlış. Instance Provider ile ezilecek.
        private ProductManager _productManager = new ProductManager(new EfProductDal());
        public void Add(Product product)
        {
            _productManager.Add(product);
        }

        public void Delete(Product product)
        {
            _productManager.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productManager.GetAll();
        }

        public Product GetById(int id)
        {
            return _productManager.GetById(id);
        }

        public void Update(Product product)
        {
            _productManager.Delete(product);
        }
    }
}
