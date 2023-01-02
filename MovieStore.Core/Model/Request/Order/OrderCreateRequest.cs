using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Model.Request.Order
{
    public class OrderCreateRequest
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
