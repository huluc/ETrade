using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.DAL.Abstract;
using ETrade.Entity.Concrete;

namespace ETrade.DAL.Concrete.EntityFramework
{
    public class EfCategoryDal :EfRepositoryBase<Category,ETradeContext>,ICategoryDal
    {

    }
}
