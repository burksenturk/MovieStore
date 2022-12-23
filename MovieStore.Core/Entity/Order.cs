using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Entity
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }

    }
}
