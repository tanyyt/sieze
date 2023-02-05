using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Connector : ComponentBase, IConnectorComponent
    {
        private static readonly int s_ShaderColorId = Shader.PropertyToID("_HdrTint");

        [SerializeField]
        private int m_MaxHp;
        [SerializeField]
        private float m_ConnectRange;
        [SerializeField]
        private CircleCollider2D m_CircleCollider;
        [SerializeField] private LineRenderer m_LineRenderer;

        private readonly List<IComponent> m_Components = new();
        private readonly Dictionary<IComponent, LineRenderer> m_C2LDict = new();
        private AudioSource m_AudioSource;

        public override int MaxHp => m_MaxHp;
        int IConnector.Count => m_Components.Count;
        float IConnector.ConnectRange => m_ConnectRange;

        void Awake()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        public override void Activate(IRoot root, IConnector connector)
        {
            base.Activate(root, connector);
            m_CircleCollider.radius = Mathf.Sqrt(m_ConnectRange);
            m_CircleCollider.gameObject.tag = root is PlayerRoot ? "ConnectorRange" : "Untagged";
        }

        public override void Deactivate()
        {
            base.Deactivate();
            for(int i = m_Components.Count - 1; i >= 0; i--)
            {
                LostConnect(m_Components[i]);
            }
        }

        public void Connect(IComponent component)
        {
            if(Root is PlayerRoot)
                m_AudioSource.Play();
            var line = Instantiate(m_LineRenderer);
            line.SetPositions(new[] { line.transform.InverseTransformPoint(gameObject.transform.position), line.transform.InverseTransformPoint(component.GameObject.transform.position) });
            component.Activate(Root, this);
            ((IConnector)this).AddComponent(component);
            component.GameObject.transform.SetParent(gameObject.transform);
            line.transform.SetParent(gameObject.transform);
            line.material.SetColor(s_ShaderColorId, Root.LineColor);
            m_C2LDict.Add(component, line);
            Root.RecalculateSpeed();
        }

        public bool LostConnect(IComponent component)
        {
            component.Deactivate();
            bool isSuccess = ((IConnector)this).RemoveComponent(component);
            component.GameObject.transform.SetParent(null);
            if (m_C2LDict.TryGetValue(component, out var line))
            {
                m_C2LDict.Remove(component);
                Destroy(line);
            }
            Root.RecalculateSpeed();
            return isSuccess;
        }

        public IEnumerator<IComponent> GetEnumerator()
        {
            return m_Components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void IConnector.AddComponent(IComponent component) => m_Components.Add(component);

        bool IConnector.RemoveComponent(IComponent component) => m_Components.Remove(component);

        bool IConnector.RequireComponent<T>(out T component)
        {
            foreach (var item in m_Components)
            {
                if (typeof(T).IsAssignableFrom(item.GetType()))
                {
                    component = (T)item;
                    return true;
                }

                // 找子节点的component
                if (item is IConnectorComponent connector && connector.RequireComponent(out component))
                {
                    return true;
                }
            }

            component = default;
            return false;
        }

        void IConnector.RequireComponents<T>(List<T> components)
        {
            components.Clear();
            foreach (var item in m_Components)
            {
                if (typeof(T).IsAssignableFrom(item.GetType()))
                {
                    components.Add((T)item);
                }

                if (item is IConnectorComponent connector)
                {
                    var childComps = new List<T>();
                    connector.RequireComponents(childComps);
                    components.AddRange(childComps);
                }
            }
        }
    }
}
