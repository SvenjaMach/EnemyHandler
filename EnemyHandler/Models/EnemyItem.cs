using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnemyHandler.Models
{
  [Serializable]
  public class EnemyItem
  {
    [Key]
    public int EnemySort { get; set; }
    public int Count { get; set; }
  }
}
