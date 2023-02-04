using UnityEngine;

namespace Model
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float m_Speed;
        private Vector2 m_Direction;
        private int m_Damage;

        public void Init(Vector2 bornPos, Vector2 target, int damage)
        {
            transform.position = bornPos;
            var pos = transform.position;
            m_Direction = (target - new Vector2(pos.x, pos.y)).normalized;
            m_Damage = damage;
        }

        void Update()
        {
            transform.Translate(m_Direction * m_Speed);
        }

        public void OnCollisionEnter2D(Collision2D col)
        {
            var entity = col.collider.GetComponent<IEntity>();
            if (entity != null)
            {
                entity.Hurt(m_Damage);
                BulletPool.Push(this);
            }
        }
    }
}