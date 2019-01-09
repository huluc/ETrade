using ETrade.DAL.Abstract;
using ETrade.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DAL.Concrete.EntityFramework
{
    public class EfProductDal : EfRepositoryBase<Product, ETradeContext>, IProductDal
    {
        
    }
}
