using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Entity
{
    public class MovieDirector : BaseEntity
    {
        public int DirectorId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Director Director { get; set; }

    }
}
