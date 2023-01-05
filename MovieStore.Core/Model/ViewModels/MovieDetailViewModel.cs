using MovieStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Model.ViewModels
{
    public class MovieDetailViewModel
    {
        public Movie Movie { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Director> Directors { get; set; }
    }
}
