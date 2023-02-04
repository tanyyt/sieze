using System.Collections;
using System.Collections.Generic;
using Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Model
{
    public class Root : MonoBehaviour, IRoot
    {
        [SerializeField] private int m_MaxHp;
        [ReadOnly] [ShowInInspector] private int m_Hp;
        private readonly List<IComponent> m_Components = new();
        public GameObject GameObject => gameObject;
        public int MaxHp => m_MaxHp;
        public int Count => m_Components.Count;

        protected virtual void Awake()
        {
            m_Hp = m_MaxHp;
            Roots.Instance.AddRoot(this);
        }

        private void OnDestroy()
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
        
        public void Connect(IComponent component)
        {
            component.Activate(this);
            ((IRoot) this).AddComponent(component);
        }

        public bool LostConnect(IComponent component) => ((IRoot) this).RemoveComponent(component);

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