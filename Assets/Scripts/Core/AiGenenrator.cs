using UnityEngine;

namespace Core
{
    public class AiGenenrator : MonoBehaviour
    {
        public Map map;
        public float generateInnerThickness = 2f;
        public Ai aiPrefab;

        void Start()
        {
            float left = (map.width - generateInnerThickness) * 0.5f;
            float top = (map.height - generateInnerThickness) * 0.5f;

            var generatedPos = new Vector2(Random.Range(-left, left), Random.Range(-top, top));
            var ai = Instantiate<Ai>(aiPrefab, generatedPos, Quaternion.identity);
            ai.Init(map);
        }
    }
}
