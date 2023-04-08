using DiziCashier.Application.Interfaces;
using DiziCashier.Core.Entities.Base;
using DiziCashier.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DiziCashier.Infrastructure.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DiziDBContext _context;

        public UnitOfWork(DiziDBContext dBContext)
        {
            _context = dBContext;
        }


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditableEntities();
            return await _context.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            if (_context is not null)
                _context.Dispose();
            GC.SuppressFinalize(this);
        }

        private void UpdateAuditableEntities()
        {
            _context.ChangeTracker.Entries<BaseEntity>().ToList().ForEach(entry =>
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedOn = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }

            });

        }
    }
}
