using Core.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MsSQL
{
    public class Repository<T> : RepositoryBase, IDataAccess<T> where T : class
    {
        private DbSet<T> _objectSet;
        private T check;
        public Repository()
        {
            _objectSet = Context.Set<T>();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);            
        }

        public bool FindTF(Expression<Func<T, bool>> where)
        {
            check = _objectSet.FirstOrDefault(where);
            if (check == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return Save();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public int Update(T obj)
        {
            return Save();
        }
    }
}
