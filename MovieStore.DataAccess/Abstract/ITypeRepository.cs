using MovieStore.Core.DataAccess.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DataAccess.Abstract
{
    public interface ITypeRepository : IRepository<Core.Entity.Type>
    {
    }
}
