using SJCNet.RecipeManager.Model.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Data.Repository.Contract
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Add(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        bool Delete(IEnumerable<T> entities);

        bool Delete(T entity);

        bool Delete(int id);

        void EagerLoad(params Expression<Func<T, object>>[] eagerLoadList);

        void FullEagerLoad();
    }
}
