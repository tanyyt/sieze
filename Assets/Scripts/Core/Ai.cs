using UnityEngine;

namespace Core
{
    public class Ai : MonoBehaviour
    {
        public Movement movement;
        public float policyTimeMin = 0.5f;
        public float policyTimeMax = 2f;
        public float moveMinimulDis = 0.1f;

        private Map m_Map;
        private float m_CachingTime;
        private float m_NextPolicyTime;
        private Vector2 m_MoveTarget;
        private Vector2 m_RotateTarget;
        private bool m_ReachedTarget;

        void Update()
        {
            var moveDir = m_MoveTarget - new Vector2(transform.position.x, transform.position.y);
            if(!m_ReachedTarget)
            {
                movement.SetDirection(moveDir);
            }
            if(moveDir.magnitude < moveMinimulDis)
            {
                m_ReachedTarget = true;
            }
            movement.SetForward(m_RotateTarget);

            if(m_CachingTime > m_NextPolicyTime)
            {
                DecidePolicy();
            }
            m_CachingTime += Time.deltaTime;
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            if(collision.collider.CompareTag("SceneWall"))
            {
                DecidePolicy();
            }
        }

        public void Init(Map map)
        {
            m_Map = map;
        }

        private void DecidePolicy()
        {
            FindNewMovementTarget();
            FindNewRotateTarget();
            m_NextPolicyTime = Random.Range(policyTimeMin, policyTimeMax);
            m_CachingTime = 0f;
        }

        private void FindNewMovementTarget()
        {
            float left = m_Map.width * 0.5f;
            float top = m_Map.height * 0.5f;

            m_MoveTarget = new Vector2(Random.Range(-left, left), Random.Range(-top, top));
            m_ReachedTarget = false;
        }

        private void FindNewRotateTarget()
        {
            m_RotateTarget = Random.insideUnitCircle;
        }
    }
}
