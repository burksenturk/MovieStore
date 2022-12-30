using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Model.Request.Director
{
    public class DirectorCreateRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
