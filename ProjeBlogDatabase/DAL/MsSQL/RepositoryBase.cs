using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MsSQL
{
    public class RepositoryBase
    {
        protected static DatabaseContext Context;
        private static object _obj = new object();
        protected RepositoryBase()
        {
            CreateContext();
        }
        private static void CreateContext()
        {
            if (Context == null)
            {
                lock (_obj)
                {
                    if (Context == null)
                    {
                        Context = new DatabaseContext();
                    }
                }
            }
        }
    }
}
