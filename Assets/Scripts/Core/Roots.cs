using System.Collections;
using System.Collections.Generic;
using Model;
using Utils;

namespace Core
{
    public class Roots : LazySingleton<Roots>, IEnumerable<IRoot>
    {
        public int Count => m_Roots.Count;
        private readonly List<IRoot> m_Roots = new();

        public void AddRoot(IRoot root)
        {
            m_Roots.Add(root);
        }

        public bool RemoveRoot(IRoot root)
        {
            return m_Roots.Remove(root);
        }

        public IEnumerator<IRoot> GetEnumerator() => m_Roots.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}