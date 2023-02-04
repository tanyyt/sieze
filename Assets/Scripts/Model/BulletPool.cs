using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public static class BulletPool
    {
        private static Stack<Bullet> s_Pool = new Stack<Bullet>();

        public static Bullet Pop()
        {
            if (s_Pool.Count > 0)
            {
                return s_Pool.Pop();
            }
            return Resources.Load<Bullet>("BulletPool");
        }

        public static void Push(Bullet bullet)
        {
            s_Pool.Push(bullet);
        }
    }

}