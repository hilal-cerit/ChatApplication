using ChatApp.Common.Entity;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DataLayer
{
    public interface IDalBase<T> where T : class,IEntity,new()
    {/*<TEntity, TDto>*/

        
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        public T? GetBy(int? id = null, string? email = null,string? userName = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        /*
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TDto GetDto(long id);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);*/


    }
}
