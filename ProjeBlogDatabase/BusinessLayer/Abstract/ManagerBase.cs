using Core.Core;
using DAL.MsSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public abstract class ManagerBase<T> : IDataAccess<T> where T : class
    {
        private Repository<T> repo = new Repository<T>();
        public int Delete(T obj)
        {
            repo.Delete(obj);
            return Save();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return repo.Find(where);
        }

        public bool FindTF(Expression<Func<T, bool>> where)
        {
            return true;
            //suan kullanilmayacak
        }

        public int Insert(T obj)
        {
            repo.Insert(obj);
            return Save();
        }

        public List<T> List()
        {
            return repo.List();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return repo.List(where);
        }

        public int Save()
        {
            return repo.Save();
        }

        public int Update(T obj)
        {
            return repo.Save();
        }
    }
}
