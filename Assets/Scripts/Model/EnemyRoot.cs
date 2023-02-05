using Core;
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
                EnemyRootsGenerator.PutWinnerAsStructure(Roots.Instance.playerRoot);
                GameEvent.gameOverEvent?.Invoke();
            }
        }
    }
}
