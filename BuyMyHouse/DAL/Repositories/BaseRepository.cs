using BuyMyHouse.Models.Interfaces;
using Microsoft.EntityFrameworkCore; 

namespace BuyMyHouse.DAL.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        protected readonly BuyHouseContext _buyMyHouseContext;

        protected BaseRepository(BuyHouseContext dbContext)
        {
            _buyMyHouseContext = dbContext;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _buyMyHouseContext.Set<T>()
                .SingleOrDefaultAsync(entity => entity.Id == id);
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _buyMyHouseContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> Create(T entity)
        {
            await _buyMyHouseContext.Set<T>().AddAsync(entity);
            await _buyMyHouseContext.SaveChangesAsync();

            return await GetById(entity.Id);
        }

        public virtual async Task<T> Update(T entity)
        {
            var entry = _buyMyHouseContext.Add(entity);
            entry.State = EntityState.Unchanged;

            _buyMyHouseContext.Set<T>().Update(entity);
            await _buyMyHouseContext.SaveChangesAsync();

            return await GetById(entity.Id);
        }

        public async Task SaveChangesAsync()
        {
            await _buyMyHouseContext.SaveChangesAsync();
        }
    }
}
