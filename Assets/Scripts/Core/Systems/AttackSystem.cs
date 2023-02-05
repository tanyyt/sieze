using System.Collections.Generic;
using Model;
using Model.Component;
using UnityEngine;

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
                foreach (var attacker in m_Attackers)
                {
                    var target = root.FindNearestRoot(AttackDistance);
                    if(target == null)
                        continue;

                    // 临时处理一下
                    if (attacker is not FixedShooter)
                    {
                        var targetTrans = target.GameObject.transform;
                        var attackerTrans = attacker.GameObject.transform;
                        attackerTrans.LookAt2D(targetTrans);
                    }

                    if (attacker.IsCooling)
                        continue;

                    attacker.Attack(root.FindNearestRoot(AttackDistance));
                }
            }
        }
    }
}