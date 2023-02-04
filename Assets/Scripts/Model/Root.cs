using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Root : MonoBehaviour, IRoot
    {
        private readonly List<IComponent> m_Components;
        public int MaxHp { get; }

        public void Hurt(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void Connect(IComponent component)
        {
            ((IRoot) this).AddComponent(component);
        }

        public bool LostConnect(IComponent component)
        {
            return ((IRoot) this).RemoveComponent(component);
        }

        void IRoot.AddComponent(IComponent component)
        {
            m_Components.Add(component);
        }

        bool IRoot.RemoveComponent(IComponent component)
        {
            return m_Components.Remove(component);
        }

        public IEnumerator<IComponent> GetEnumerator()
        {
            return m_Components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}