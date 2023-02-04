using UnityEngine;

namespace Core
{
    public class EnemyRootsGenerator : EntityGenerator
    {
        public EnemyRootsGenerator(Map map) : base(map) { }
        protected override void OnGenerate(Vector2 pos)
        {
            var ai = Object.Instantiate(Resources.Load<Ai>("Prefabs/AiRoot"), pos, Quaternion.identity);
            ai.Init(Map);
        }
    }
}