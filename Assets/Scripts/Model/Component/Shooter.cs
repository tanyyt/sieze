using UnityEngine;

namespace Model.Component
{
    public class Shooter : Attacker
    {
        [SerializeField] private int m_MaxHp = 5;
        [SerializeField] private int m_Atk = 1;
        [SerializeField] private float m_CoolingTime = 3f;
        public override int MaxHp => m_MaxHp;
        public override int Atk => m_Atk;
        protected override float coolingTime => m_CoolingTime;

        protected override void AttackEntity(IEntity entity)
        {
            var bullet = BulletPool.Pop();
            bullet.Init(transform.position, entity.GameObject.transform.position, Atk);
        }
    }
}