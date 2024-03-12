using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IBaseBL<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetByPrimaryKey(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}