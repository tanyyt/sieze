using System.Collections;
using Core;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Model
{
    public abstract class ComponentBase : MonoBehaviour, IComponent
    {
        private static readonly int s_ShaderColorId = Shader.PropertyToID("_HdrTint");

        [ReadOnly] [ShowInInspector] private int Hp;
        [SerializeField] private string m_ConnectorTag = "ConnectorRange";
        [SerializeField] private Collider2D m_Collider;

        [SerializeField, ColorUsage(true, hdr: true)]
        private Color m_DeactivateColor;

        [SerializeField, ColorUsage(true, hdr: true)]
        private Color m_InConnectorRangeColor;

        [SerializeField, ColorUsage(true, hdr: true)]
        private Color m_HurtColor;

        [SerializeField] private Renderer[] m_Renderers;

        private int m_InConnectorRangeCount;

        public bool IsInConnectorRange => m_InConnectorRangeCount > 0;
        public GameObject GameObject => gameObject;
        public IConnector Connector { get; private set; }
        public abstract int MaxHp { get; }

        public IRoot Root { get; private set; }

        void OnDestroy()
        {
            DeactivateComponents.Instance.RemoveComponent(this);
        }

        void Update()
        {
            if(Root == null)
            {
                transform.up = transform.up + Time.deltaTime * 5f * transform.right;
            }
        }

        public virtual void Activate(IRoot root, IConnector connector)
        {
            Hp = MaxHp;
            Root = root;
            Connector = connector;
            m_InConnectorRangeCount = 0;
            m_Collider.isTrigger = false;
            foreach (var renderer in m_Renderers)
            {
                renderer.material.SetColor(s_ShaderColorId, root.Color);
            }

            DeactivateComponents.Instance.RemoveComponent(this);
        }

        public void Hurt(int damage)
        {
            Hp -= damage;
            if (Hp <= 0)
            {
                GameEvent.cameraHugeShake?.Invoke();
                Connector.LostConnect(this);
            }
            else
                Warning();
        }


        protected virtual void Warning()
        {
            var curCol = m_Renderers[0].material.GetColor(s_ShaderColorId);
            var rootCol = Root.Color;
            var diff = Mathf.Abs(Vector3.Dot(new Vector3(curCol.r, curCol.g, curCol.b).normalized , new Vector3(rootCol.r, rootCol.g, rootCol.b).normalized));
            if(diff > 0.75f)
                StartCoroutine(GameUtils.HurtCoroutine(m_Renderers, s_ShaderColorId, Root));
        }

        public virtual void Deactivate()
        {
            StopAllCoroutines();
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
            if (null == Root && collision.CompareTag(m_ConnectorTag))
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
                if (m_InConnectorRangeCount == 0)
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