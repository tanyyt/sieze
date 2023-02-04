using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Model
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float m_Speed = 8;
        [SerializeField] private float m_LifeTime = 4f;
        private Vector2 m_Direction;
        private int m_Damage;
        private IRoot m_Shotter;
        private float m_Countdown;

        public void Init(IRoot shooter, Vector2 bornPos, Vector2 target, int damage)
        {
            m_Shotter = shooter;
            transform.position = bornPos;
            var pos = transform.position;
            m_Direction = (target - new Vector2(pos.x, pos.y)).normalized;
            m_Damage = damage;
        }

        private void OnEnable()
        {
            m_Countdown = 0;
        }

        void Update()
        {
            m_Countdown += Time.deltaTime;
            if (m_Countdown >= m_LifeTime)
            {
                m_Countdown = 0;
                BulletPool.Push(this);
            }
            else
                transform.Translate(m_Direction * (m_Speed * Time.deltaTime));
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            var entity = col.GetComponent<IEntity>();

            if (entity != null 
                && ((entity is IComponent component && component.Root != null && component.Root != m_Shotter) 
                    || (entity is Root && entity != m_Shotter)))
            {
                entity.Hurt(m_Damage);
                BulletPool.Push(this);
            }
        }
    }
}