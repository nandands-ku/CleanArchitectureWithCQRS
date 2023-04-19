using DiziCashier.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziCashier.Infrastructure.Data
{
    public class DiziDBContext : DbContext
    {
        public DiziDBContext(DbContextOptions<DiziDBContext> options) : base(options)
        {
        }        
        public DbSet<ItemCategory> ItemCategories { get; set; }
    }
}
