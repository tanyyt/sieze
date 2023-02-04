using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Connector : ComponentBase, IConnectorComponent
    {
        [SerializeField]
        private int m_MaxHp;
        [SerializeField]
        private float m_ConnectRange;
        [SerializeField]
        private CircleCollider2D m_CircleCollider;
        private readonly List<IComponent> m_Components = new();
        private AudioSource audioSource;

        private void Awake() => audioSource = GetComponent<AudioSource>();

        public override int MaxHp => m_MaxHp;

        int IConnector.Count => m_Components.Count;
        float IConnector.ConnectRange => m_ConnectRange;

        public override void Activate(IRoot root, IConnector connector)
        {
            base.Activate(root, connector);
            m_CircleCollider.radius = Mathf.Sqrt(m_ConnectRange);
        }

        public void Connect(IComponent component)
        {
            if (Root is PlayerRoot)
            {
                Debug.Log("Connect");
                audioSource.Play();
            }
            component.Activate(Root, this);
            ((IConnector)this).AddComponent(component);
            component.GameObject.transform.SetParent(GameObject.transform);
        }

        public bool LostConnect(IComponent component)
        {
            component.Deactivate();
            bool isSuccess = ((IConnector)this).RemoveComponent(component);
            component.GameObject.transform.SetParent(null);
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
