using UnityEngine;

namespace Core
{
    public class EnemyRootsGenerator : EntityGenerator
    {
        private bool m_HasGenerated = false;

        public EnemyRootsGenerator(Map map) : base(map) { }
        protected override void OnGenerate(Vector2 pos)
        {
            if(m_HasGenerated)
            {
                return;
            }
            var ai = Object.Instantiate(Resources.Load<Ai>("Prefabs/AiRoot"), pos, Quaternion.identity);
            ai.Init(Map);
            m_HasGenerated = true;
        }
    }
}