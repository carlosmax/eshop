namespace Catalog.Core.Common
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);        
        Task<T> Create(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(string id);
    }
}
