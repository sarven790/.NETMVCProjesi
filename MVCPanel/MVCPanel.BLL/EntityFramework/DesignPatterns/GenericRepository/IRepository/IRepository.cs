using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MVCPanel.Entities.Models;

namespace MVCPanel.BLL.EntityFramework.DesignPatterns.GenericRepository.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        List<T> GetAllForID(int id);
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetModifieds();


        void Add(T item);
        void Delete(T item);
        void Update(T item);
        void Destroy(T item);


        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);


        T Find(int id);

    }
}
