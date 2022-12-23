using MovieStore.Core.DataAccess.Ef;
using MovieStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DataAccess.Abstract
{
    public interface IMovieRepository : IRepository<Movie>
    {

    }
}
