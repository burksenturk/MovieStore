using Microsoft.EntityFrameworkCore;
using MovieStore.Core.DataAccess.Ef;
using MovieStore.Core.Entity;
using MovieStore.DataAccess.Abstract;
using MovieStore.DataAccess.Concrete.Ef.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DataAccess.Concrete
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        private MovieStoreContext _context;

        public CustomerRepository(MovieStoreContext context):base(context)
        {
            _context = context;
        }
    }
}
