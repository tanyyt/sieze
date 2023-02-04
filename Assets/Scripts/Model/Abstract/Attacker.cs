using Sirenix.OdinInspector;
using UnityEngine;

namespace Model
{
    public abstract class Attacker : ComponentBase, IAttacker
    {
        
        [ReadOnly]
        [ShowInInspector]
        bool m_IsCooling = false;
        public abstract int Atk { get; }
        protected abstract float coolingTime { get; }
        public bool IsCooling => m_IsCooling;
        private float m_Countdown;

        void OnEnable()
        {
            m_IsCooling = false;
        }

        void Update()
        {
            m_Countdown += Time.deltaTime;
            if (m_Countdown > coolingTime)
            {
                m_Countdown = 0;
                m_IsCooling = false;
            }
        }


        public void Attack(IRoot root)
        {
            if (root == null) return;
            m_IsCooling = true;
            if (root.Count == 0)
            {
                AttackEntity(root);
            }
            else
            {
                AttackEntity(transform.GetNearComponent(root));
            }
        }

        protected abstract void AttackEntity(IEntity entity);
    }
}