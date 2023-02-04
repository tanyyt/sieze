using Model;

namespace Core
{
    public class AttackSystem : ISystem
    {
        private readonly float AttackDistance = 150f;

        public void Update(Roots roots)
        {
            foreach (var root in roots)
            {
                if (root.RequireComponent<IAttacker>(out var attacker) && !attacker.IsCooling)
                {
                    attacker.Attack(root.FindNearestRoot(AttackDistance));
                }
            }
        }
    }
}