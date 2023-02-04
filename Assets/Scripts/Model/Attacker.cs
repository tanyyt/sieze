using UnityEngine;

namespace Model
{
    public class Attacker : ComponentBase,IAttacker
    {
        public int Atk { get; }

        public void Attack(Transform target)
        {
            var bullet = BulletPool.Pop();
        }
        
    }
}