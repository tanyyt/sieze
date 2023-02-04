using UnityEngine;

namespace Core
{
    public abstract class EntityGenerator
    {
        public float generateInnerThickness = 2f;
        public Ai aiPrefab;
        private float m_Left;
        private float m_Top;
        protected Map Map { get; private set; }

        public EntityGenerator(Map map)
        {
            Map = map;
            m_Left = (map.width - generateInnerThickness) * 0.5f;
            m_Top = (map.height - generateInnerThickness) * 0.5f;
        }

        public void Generate()
        {
            OnGenerate(new Vector2(Random.Range(-m_Left, m_Left), Random.Range(-m_Top, m_Top)));
        }

        protected abstract void OnGenerate(Vector2 pos);
    }
}