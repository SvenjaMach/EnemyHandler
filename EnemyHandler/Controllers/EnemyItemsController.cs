using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnemyHandler.Models;
using Newtonsoft.Json;

namespace EnemyHandler.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EnemyItemsController : ControllerBase
  {
    private readonly EnemyDbContext _enemyContext;
    private readonly AchievementDbContext _achievementContext;

    public EnemyItemsController(EnemyDbContext enemyContext, AchievementDbContext achievementContext)
    {
      _enemyContext = enemyContext;
      _achievementContext = achievementContext;
    }

    // GET: api/EnemyItems
    [HttpGet]
    public string GetAchievements()
    {
      AchievementItems achievements = new AchievementItems();
      achievements.achievements = AchievementHandler.GetNewlyReachedAchievements(_achievementContext, _enemyContext);
      return JsonConvert.SerializeObject(achievements);
    }
  }
}
