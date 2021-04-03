using DAL.MsSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TRN
    {
        protected static DatabaseContext context;
        private static object obj_ = new object();
        public TRN()
        {
            CreateC();
        }
        private static void CreateC()
        {
            if (context==null)
            {
                lock (obj_)
                {
                    if (context== null)
                    {
                        context = new DatabaseContext();
                    }
                }
            }
        }
    }
}
