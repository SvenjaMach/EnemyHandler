using EnemyHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemyHandler
{
  public static class AchievementHandler
  {
    public static void AddEnemySort(int enemySort, AchievementDbContext achievementDbContext)
    {
      if(!achievementDbContext.AchievementItems.Any(o => o.EnemySort == enemySort))
      {
        achievementDbContext.Add(new AchievementItem() { EnemySort = enemySort, NeededCount = 5, Achieved = false });
        achievementDbContext.Add(new AchievementItem() { EnemySort = enemySort, NeededCount = 10, Achieved = false });
        achievementDbContext.Add(new AchievementItem() { EnemySort = enemySort, NeededCount = 20, Achieved = false });
        achievementDbContext.Add(new AchievementItem() { EnemySort = enemySort, NeededCount = 30, Achieved = false });
        achievementDbContext.SaveChanges();
      }
    }

    public static List<AchievementItem> GetNewlyReachedAchievements(AchievementDbContext achievementDbContext, EnemyDbContext enemyDbContext)
    {
      var unreachedAchievements = achievementDbContext.AchievementItems.Where(a => a.Achieved == false);
      var currentlyKilled = enemyDbContext.EnemyItems.ToList();
      List<AchievementItem> reachedAchievements = new List<AchievementItem>();

      foreach (EnemyItem enemySort in currentlyKilled)
      {
        foreach(AchievementItem achievement in unreachedAchievements)
        {
          if(enemySort.Count >= achievement.NeededCount)
          {
            reachedAchievements.Add(achievement);
            achievement.Achieved = true;
            achievementDbContext.SaveChanges();
          }
        }
      }

      return reachedAchievements;
    }
  }
}
