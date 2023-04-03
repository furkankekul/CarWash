using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Model
    { 
        public HttpStatusCode Status { get; set; }
        public string StatuMessage { get; set; }
        public object models { get; set; }
      
    }
}
