using EnemyHandler.Models;
using MassTransit;
using rabbitmq_damagemessage;
using System.Threading.Tasks;


namespace EnemyHandler
{
  public class DamageCalculatorConsumer :
     IConsumer<IEnemyMessage>
  {
    public DamageCalculatorConsumer(EnemyDbContext enemyContext, AchievementDbContext achievementContext)
    {
      _enemyContext = enemyContext;
      _achievementContext = achievementContext;
    }

    private readonly EnemyDbContext _enemyContext;
    private readonly AchievementDbContext _achievementContext;
    public async Task Consume(ConsumeContext<IEnemyMessage> message)
    {
      var data = message.Message;
      var enemySort = _enemyContext.Find<EnemyItem>(data.EnemySort);

      if(enemySort == null)
      {
        _enemyContext.Add<EnemyItem>(new EnemyItem { Count = 1, EnemySort = data.EnemySort });
      }
      else
      {
        enemySort.Count += data.Count;
      }

      await _enemyContext.SaveChangesAsync();
      AchievementHandler.AddEnemySort(data.EnemySort, _achievementContext);
    }
  }
}
