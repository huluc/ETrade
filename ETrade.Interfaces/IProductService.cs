using ETrade.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Interfaces
{
    //Bir sınıfı WDF servisi olarak yayına çıkarmak için
    [ServiceContract] //Servis katmanı olarak hizmeti açıldı
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAll();

        [OperationContract]
        Product GetById(int id);

        [OperationContract]
        void Add(Product product);

        [OperationContract]
        void Update(Product product);

        [OperationContract]
        void Delete(Product product);

        [OperationContract]
        List<Product> GetByCategoryId(int id);
    }
}
