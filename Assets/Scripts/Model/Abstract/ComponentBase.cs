using Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Model
{
    public abstract class ComponentBase : MonoBehaviour, IComponent
    {
        [ReadOnly]
        [ShowInInspector]
        private int Hp;
        [SerializeField]
        private string m_ConnectorTag = "ConnectorRange";
        [SerializeField]
        private Collider2D m_Collider;
        [SerializeField, ColorUsage(true, hdr: true)]
        private Color m_DeactivateColor;
        [SerializeField, ColorUsage(true, hdr: true)]
        private Color m_ActivateColor;

        private int m_InConnectorRangeCount;

        public bool IsInConnectorRange => m_InConnectorRangeCount > 0;
        public GameObject GameObject => gameObject;
        public abstract int MaxHp { get; }
        
        public IRoot Root { get; private set; }

        public virtual void Activate(IRoot root)
        {
            Hp = MaxHp;
            Root = root;
            m_InConnectorRangeCount = 0;
            m_Collider.isTrigger = false;
            DeactivateComponents.Instance.RemoveComponent(this);
        }

        public void Hurt(int damage)
        {
            Hp -= damage;
            if (Hp <= 0) 
                Deactivate();
            else if (Hp < MaxHp / 2)
                Warning();
        }

        protected virtual void Warning()
        {
                       
        }

        public virtual void Deactivate()
        {
            Root = null;
            m_Collider.isTrigger = true;
            DeactivateComponents.Instance.AddComponent(this);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if(null == Root && collision.CompareTag(m_ConnectorTag))
            {
                m_InConnectorRangeCount++;
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (null == Root && collision.CompareTag(m_ConnectorTag))
            {
                m_InConnectorRangeCount--;
            }
        }
    }
}