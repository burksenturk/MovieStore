using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Model.Request.Type
{
    public class TypeUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
