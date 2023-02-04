using System;
using UnityEngine;

namespace Model
{
    public class ComponentBase : MonoBehaviour, IComponent
    {
        public int Hp;
        public int MaxHp { get; }

        protected virtual void Awake()
        {
            Hp = MaxHp;
        }

        public void Hurt(int damage)
        {
            Hp -= damage;
            if (Hp < 0) 
                Dead();
            else if (Hp < MaxHp / 2)
                Warning();
        }

        public void Warning()
        {
            Debug.Log("Hp < 50%");
        }

        public void Dead()
        {
            Debug.Log("Component Dead!");
        }
    }
}