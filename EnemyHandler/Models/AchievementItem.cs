using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnemyHandler.Models
{
  [Serializable]
  public class AchievementItem
  {
    [Key]
    public int AchievementId { get; set; }
    public int NeededCount { get; set; }
    public int EnemySort { get; set; }
    public bool Achieved { get; set; }
  }
}
