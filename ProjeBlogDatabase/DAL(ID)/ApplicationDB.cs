using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ID_
{
    public class ApplicationDB : IdentityDbContext<ApplicataionUser>
    {
        public ApplicationDB():base("DatabaseContext2")
        {
            
        }
    }
}
