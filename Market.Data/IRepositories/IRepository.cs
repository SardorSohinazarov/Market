using System.Linq.Expressions;

namespace Market.Data.IRepositories
{
    public interface IRepository<TSourse> where TSourse : class
    {
        Task<TSourse> AddAsync(TSourse entity);
        IQueryable<TSourse> GetAll(Expression<Func<TSourse, bool>> expression = null, string include = null, bool tracking = true);
        Task<TSourse> GetAsync(Expression<Func<TSourse,bool>> expression = null, string include = null);
        Task<TSourse> UpdateAsync(TSourse entity);
        Task DeleteAsync(Expression<Func<TSourse,bool>> expression);
    }
}
