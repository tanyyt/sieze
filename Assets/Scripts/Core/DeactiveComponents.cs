using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using Utils;

namespace Core
{
    public class DeactivateComponents : LazySingleton<DeactivateComponents>, IReadOnlyList<IComponent>
    {
        public int Count => m_DeactivateComponents.Count;
        IComponent IReadOnlyList<IComponent>.this[int index] => m_DeactivateComponents[index];

        public DeactivateComponents()
        {
            EventScheduler<GameEvent>.Global.RegisterOrSubscribe(GameEvent.GameOver,ClearComponents);
        }

        public readonly List<IComponent> m_DeactivateComponents = new List<IComponent>();

        public void ClearComponents()
        {
            m_DeactivateComponents.Clear();  
            Debug.Log("ClearComponents");
        } 
        public void AddComponent(IComponent component) => m_DeactivateComponents.Add(component);
        public bool RemoveComponent(IComponent component) => m_DeactivateComponents.Remove(component);
        public IEnumerable<IComponent> GetCloneList() => new List<IComponent>(m_DeactivateComponents);

        IEnumerator<IComponent> IEnumerable<IComponent>.GetEnumerator() => m_DeactivateComponents.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => m_DeactivateComponents.GetEnumerator();
    }
}