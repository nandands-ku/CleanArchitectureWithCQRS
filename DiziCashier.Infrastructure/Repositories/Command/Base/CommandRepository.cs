using DiziCashier.Core.Command.Base;
using DiziCashier.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DiziCashier.Infrastructure.Repositories.Command.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly DiziDBContext _context;
        public CommandRepository(DiziDBContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }


    }
}
