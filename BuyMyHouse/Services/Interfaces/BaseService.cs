using BuyMyHouse.DAL.Repositories;
using BuyMyHouse.Models.Interfaces;

namespace BuyMyHouse.Services.Interfaces
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, IEntity
    {
        protected readonly IBaseRepository<T> _repository;

        protected BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> GetById(Guid id) => await _repository.GetById(id);

        public virtual async Task<ICollection<T>> GetAll() => await _repository.GetAll();

        public virtual async Task<T> Create(T entity) => await _repository.Create(entity);

        public virtual async Task<T> Update(T entity) => await _repository.Update(entity);

    }
}
