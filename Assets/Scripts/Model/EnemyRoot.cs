using Core;
using UnityEngine;
using Utils;

namespace Model
{
    public class EnemyRoot : Root
    {
        protected override void OnDestroy()
        {
            base.OnDestroy();
            if(!GamePlay.isGameOver)
            {
                
                Debug.Log($"EnemyRoot:  { EventScheduler<GameEvent>.Global[GameEvent.GameOver] == null}");
                EventScheduler<GameEvent>.Global[GameEvent.GameOver]?.Broadcast();
            }
        }
    }
}
