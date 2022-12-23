using Microsoft.EntityFrameworkCore;
using MovieStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DataAccess.Concrete.Ef.Contexts
{
    public class MovieStoreContext:DbContext
    {
        public MovieStoreContext() : base()
        {

        }

        public MovieStoreContext(DbContextOptions<MovieStoreContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<CustomerFavoriteType> CustomerFavoriteTypes { get; set; }  //isim çoğul olayı? düzelttim
        public DbSet< Core.Entity.Type> Types { get; set; }

    }
}

