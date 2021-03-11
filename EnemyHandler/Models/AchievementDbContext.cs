using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemyHandler.Models
{
  public class AchievementDbContext: DbContext
  {
    public AchievementDbContext(DbContextOptions<AchievementDbContext> options)
        : base(options)
    {
    }

    public DbSet<AchievementItem> AchievementItems { get; set; }
  }
}
