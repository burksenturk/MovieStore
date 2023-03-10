using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Model.Request.Movie
{
    public class MovieUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public int TypeId { get; set; }
        public decimal Price { get; set; }
    }
}
