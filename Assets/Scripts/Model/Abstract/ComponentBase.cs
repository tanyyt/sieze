using Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Model
{
    public abstract class ComponentBase : MonoBehaviour, IComponent
    {
        private static readonly int s_ShaderColorId = Shader.PropertyToID("_HdrTint");

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
        private Color m_InConnectorRangeColor;
        [SerializeField]
        private Renderer[] m_Renderers;

        private int m_InConnectorRangeCount;

        public bool IsInConnectorRange => m_InConnectorRangeCount > 0;
        public GameObject GameObject => gameObject;
        public IConnector Connector { get; private set; }
        public abstract int MaxHp { get; }
        
        public IRoot Root { get; private set; }

        public virtual void Activate(IRoot root, IConnector connector)
        {
            Hp = MaxHp;
            Root = root;
            Connector = connector;
            m_InConnectorRangeCount = 0;
            m_Collider.isTrigger = false;
            foreach(var renderer in m_Renderers)
            {
                renderer.material.SetColor(s_ShaderColorId, root.Color);
            }
            DeactivateComponents.Instance.RemoveComponent(this);
        }

        public void Hurt(int damage)
        {
            Hp -= damage;
            if (Hp <= 0)
                Connector.LostConnect(this);
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
            foreach (var renderer in m_Renderers)
            {
                renderer.material.SetColor(s_ShaderColorId, m_DeactivateColor);
            }
            DeactivateComponents.Instance.AddComponent(this);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if(null == Root && collision.CompareTag(m_ConnectorTag))
            {
                m_InConnectorRangeCount++;
                foreach (var renderer in m_Renderers)
                {
                    renderer.material.SetColor(s_ShaderColorId, m_InConnectorRangeColor);
                }
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (null == Root && collision.CompareTag(m_ConnectorTag))
            {
                m_InConnectorRangeCount--;
                if(m_InConnectorRangeCount == 0)
                {
                    foreach (var renderer in m_Renderers)
                    {
                        renderer.material.SetColor(s_ShaderColorId, m_DeactivateColor);
                    }
                }
            }
        }
    }
}