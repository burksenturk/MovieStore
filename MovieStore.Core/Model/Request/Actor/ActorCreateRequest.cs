using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Model.Request.Actor
{
    public class ActorCreateRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
