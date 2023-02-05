using System;
using UnityEngine;

namespace Model
{
    public class Bullet : MonoBehaviour
    {
        private static readonly int s_ShaderColorId = Shader.PropertyToID("_HdrTint");
        [SerializeField] private float m_Speed = 8;
        [SerializeField] private float m_LifeTime = 4f;
        private int m_Damage;
        private IRoot m_Shooter;
        private float m_Countdown;
        private Color m_CurColor;

        private void Awake()
        {
            m_CurColor = GetComponent<SpriteRenderer>().material.GetColor(s_ShaderColorId);
            m_CurColor.a = 1f;
        }

        public void Init(IRoot shooter, Vector2 bornPos, Vector2 target, int damage)
        {
            m_Shooter = shooter;
            transform.position = bornPos;
            var pos = transform.position;
            var direction = (target - new Vector2(pos.x, pos.y)).normalized;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            m_Damage = damage;
            var color = Color.Lerp(m_CurColor, shooter.Color, 0.65f);
            GetComponent<SpriteRenderer>().material.SetColor(s_ShaderColorId,color);
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
                transform.Translate(transform.right * (m_Speed * Time.deltaTime), Space.World);
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            var entity = col.GetComponent<IEntity>();

            if (entity != null
                && ((entity is IComponent component && component.Root != null && component.Root != m_Shooter)
                    || (entity is Root && entity != m_Shooter)))
            {
                entity.Hurt(m_Damage);
                BulletPool.Push(this);
            }
        }
    }
}