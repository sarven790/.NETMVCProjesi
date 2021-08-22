using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MVCPanel.BLL.EntityFramework.DesignPatterns.GenericRepository.IRepository;
using MVCPanel.BLL.EntityFramework.DesignPatterns.SingletonPattern;
using MVCPanel.DAL.Context;
using MVCPanel.Entities.Enums;
using MVCPanel.Entities.Models;

namespace MVCPanel.BLL.EntityFramework.DesignPatterns.GenericRepository.BaseRepository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        MyContext _db;
        public BaseRepository()
        {
            _db = DBTool.DbInstance;
        }


        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        private void Save()
        {
            _db.SaveChanges();
        }




        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.DeletedDate = DateTime.Now;
            item.Status = DataStatus.Deleted;
            Save();
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);

        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetAllForID(int id)
        {

            T toFind = Find(id);

            return _db.Set<T>().Where(x => x.ID == id).ToList();
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == DataStatus.Updated);
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == DataStatus.Deleted);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public void Update(T item)
        {
            item.UpdatedDate = DateTime.Now;
            item.Status = DataStatus.Updated;
            T toBeUpdated = Find(item.ID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();


        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
      
    }
}
