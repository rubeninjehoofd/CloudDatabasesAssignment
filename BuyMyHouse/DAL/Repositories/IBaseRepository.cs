using BuyMyHouse.Models.Interfaces;

namespace BuyMyHouse.DAL.Repositories
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        public Task<T> GetById(Guid id);

        public Task<ICollection<T>> GetAll();

        public Task<T> Create(T entity);

        public Task<T> Update(T entity);

        public Task SaveChangesAsync();
    }
}
