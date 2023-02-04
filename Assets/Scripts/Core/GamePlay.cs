using UnityEngine;

namespace Core
{
    public class GamePlay : MonoBehaviour
    {
        private readonly ISystem[] m_Systems = {
            new AttackSystem()
        };
        void Update()
        {
            foreach (var system in m_Systems)
            {
                system.Update(Roots.Instance);
            }
        }
    }
}