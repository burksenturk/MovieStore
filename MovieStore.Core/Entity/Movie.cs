using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Entity
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public int? Year { get; set; }
        public int TypeId { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        public virtual Type Type { get; set; }

    }
}
