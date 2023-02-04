using System.Collections;
using System.Collections.Generic;
using Model;
using Utils;

namespace Core
{
    public class Roots : LazySingleton<Roots>,IEnumerable<IRoot>
    {
        private readonly List<IRoot> m_Roots = new List<IRoot>();
        public void ForeachActiveRoot()
        {
               
        }

        public IEnumerator<IRoot> GetEnumerator() => m_Roots.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() =>GetEnumerator();
    }
}