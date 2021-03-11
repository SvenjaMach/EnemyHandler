using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemyHandler.Models
{
  public class EnemyDbContext: DbContext
  {
    public EnemyDbContext(DbContextOptions<EnemyDbContext> options)
        : base(options)
    {
    }

    public DbSet<EnemyItem> EnemyItems { get; set; }
  }
}
