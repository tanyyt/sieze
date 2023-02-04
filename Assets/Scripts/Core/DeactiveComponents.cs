using System.Collections;
using System.Collections.Generic;
using Model;
using Utils;

namespace Core
{
    public class DeactivateComponents : LazySingleton<DeactivateComponents>,IEnumerable<IComponent>
    {
        public int Count => m_DeactivateComponents.Count;
        public readonly List<IComponent> m_DeactivateComponents = new List<IComponent>();
        public void AddComponent(IComponent component) => m_DeactivateComponents.Add(component);
        public bool RemoveComponent(IComponent component) => m_DeactivateComponents.Remove(component);
        public IEnumerator<IComponent> GetEnumerator() => m_DeactivateComponents.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}