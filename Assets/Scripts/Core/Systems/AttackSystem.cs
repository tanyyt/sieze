using System.Collections.Generic;
using Model;

namespace Core
{
    public class AttackSystem : ISystem
    {
        private readonly float AttackDistance = 150f;
        private readonly List<IAttacker> m_Attackers = new List<IAttacker>();

        public void Update(Roots roots)
        {
            foreach (var root in roots)
            {
                root.RequireComponents(m_Attackers);
                foreach(var attacker in m_Attackers)
                {
                    if(attacker.IsCooling)
                    {
                        continue;
                    }
                    attacker.Attack(root.FindNearestRoot(AttackDistance));
                }
            }
        }
    }
}