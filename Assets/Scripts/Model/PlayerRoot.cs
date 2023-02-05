using Core;
using Utils;

namespace Model
{
    public class PlayerRoot : Root
    {
        protected override void Awake()
        {
            base.Awake();
            Roots.Instance.playerRoot = this;
        }

        protected override void OnDestroy()
        {
            Roots.Instance.playerRoot = null;
            EventScheduler<GameEvent>.Global[GameEvent.GameOver].Broadcast();
        }
    }
}
