using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public static class BulletPool
    {
        private static readonly Stack<Bullet> s_Pool = new Stack<Bullet>();

        public static Bullet Pop()
        {
            if (s_Pool.Count > 0)
            {
                var bullet = s_Pool.Pop();
                bullet.gameObject.SetActive(true);
                return bullet;
            }
            return Object.Instantiate(Resources.Load<Bullet>("Prefabs/Bullet"));
        }

        public static void Push(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            s_Pool.Push(bullet);
        }
    }

}