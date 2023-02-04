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

        void OnDestroy()
        {
            Roots.Instance.playerRoot = null;
        }
        void TestPlayer()
        {}
    }
}
