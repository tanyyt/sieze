using UnityEngine;

namespace Model.Component
{
    public class FixedShooter : Attacker
    {
        [SerializeField] private int m_MaxHp = 5;
        [SerializeField] private int m_Atk = 1;
        [SerializeField] private float m_CoolingTime = 3f;
        public override int MaxHp => m_MaxHp;
        public override int Atk => m_Atk;
        protected override float coolingTime => m_CoolingTime;
        private AudioSource m_AudioSource;

        private void Awake()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }
        protected override void AttackEntity(IEntity entity)
        {
            m_AudioSource.Play();
            var bullet = BulletPool.Pop();
            bullet.Init(Root, transform.position, transform.position + transform.right, Atk);
        }
    }
}