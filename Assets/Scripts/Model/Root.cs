using System.Collections;
using System.Collections.Generic;
using Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Model
{
    public class Root : MonoBehaviour, IRoot
    {
        private static readonly int s_ShaderColorId = Shader.PropertyToID("_HdrTint");

        [SerializeField] private int m_MaxHp;
        [SerializeField] private float m_ConnectRange;
        [SerializeField] private CircleCollider2D m_CircleCollider;
        [SerializeField, ColorUsage(true, hdr: true)] private Color m_Color;
        [SerializeField, ColorUsage(true, hdr: true)] private Color m_LineColor;
        [SerializeField] private LineRenderer m_LineRenderer;
        [ReadOnly] [ShowInInspector] private int m_Hp;
        private readonly List<IComponent> m_Components = new();
        private readonly Dictionary<IComponent, LineRenderer> m_C2LDict = new();
        public GameObject GameObject => gameObject;
        public int MaxHp => m_MaxHp;
        public int Count => m_Components.Count;
        public float ConnectRange => m_ConnectRange;
        public Color Color => m_Color;
        public Color LineColor => m_LineColor;

        protected virtual void Awake()
        {
            m_Hp = m_MaxHp;
            if(null != m_CircleCollider)
            {
                m_CircleCollider.radius = Mathf.Sqrt(m_ConnectRange);
            }
            Roots.Instance.AddRoot(this);
        }

        protected virtual void OnDestroy()
        {
            Roots.Instance.RemoveRoot(this);
        }

        public void Hurt(int damage)
        {
            m_Hp -= damage;
            if (m_Hp <= 0)
            {
                DeactivateComponents();
                Roots.Instance.RemoveRoot(this);
                Destroy(gameObject);
            }
        }
        
        public virtual void Connect(IComponent component)
        {
            var line = Instantiate(m_LineRenderer);
            line.SetPositions(new[] { line.transform.InverseTransformPoint(gameObject.transform.position), line.transform.InverseTransformPoint(component.GameObject.transform.position) });
            component.Activate(this, this);
            ((IRoot) this).AddComponent(component);
            component.GameObject.transform.SetParent(gameObject.transform);
            line.transform.SetParent(gameObject.transform);
            line.material.SetColor(s_ShaderColorId, m_LineColor);
            m_C2LDict.Add(component, line);
        }

        public bool LostConnect(IComponent component)
        {
            component.Deactivate();
            bool isSuccess = ((IRoot)this).RemoveComponent(component);
            component.GameObject.transform.SetParent(null);
            if(m_C2LDict.TryGetValue(component, out var line))
            {
                m_C2LDict.Remove(component);
                Destroy(line);
            }
            return isSuccess;
        }

        public bool RequireComponent<T>(out T component) where T : IComponent
        {
            foreach (var item in m_Components)
            {
                if (typeof(T).IsAssignableFrom(item.GetType()))
                {
                    component = (T) item;
                    return true;
                }

                // 找子节点的component
                if(item is IConnectorComponent connector && connector.RequireComponent(out component))
                {
                    return true;
                }
            }

            component = default;
            return false;
        }

        private void DeactivateComponents()
        {
            foreach (var component in m_Components)
            {
                component.Deactivate();
            }
        }

        void IConnector.AddComponent(IComponent component) => m_Components.Add(component);

        bool IConnector.RemoveComponent(IComponent component) => m_Components.Remove(component);

        public IEnumerator<IComponent> GetEnumerator() => m_Components.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void RequireComponents<T>(List<T> components) where T : IComponent
        {
            components.Clear();
            foreach (var item in m_Components)
            {
                if (typeof(T).IsAssignableFrom(item.GetType()))
                {
                    components.Add((T)item);
                }

                if(item is IConnectorComponent connector)
                {
                    var childComps = new List<T>();
                    connector.RequireComponents(childComps);
                    components.AddRange(childComps);
                }
            }
        }
    }
}