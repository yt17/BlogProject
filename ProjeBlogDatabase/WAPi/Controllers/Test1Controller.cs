using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WAPi.Controllers
{
    public class kisi{
        public int Id { get; set; }
        public string ad { get; set; }
    }
    public class Test1Controller : ApiController
    {
        kisi[] x = new kisi[] {
            new kisi { Id = 0, ad = "yusuf0" },
            new kisi { Id = 1, ad = "yusuf1" },
            new kisi { Id = 2, ad = "yusuf2" }
        };
        
       
        public IEnumerable<kisi> GetAllKisi()
        {
            return x;
        }




    }
}
