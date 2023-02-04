using System.Xml.Linq;
using Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Model
{
    public abstract class ComponentBase : MonoBehaviour, IComponent
    {
        [ReadOnly]
        [ShowInInspector]
        private int Hp;
        public GameObject GameObject => gameObject;
        public abstract int MaxHp { get; }
        
        public IRoot Root { get; private set; }

        public void Activate(IRoot root)
        {
            Hp = MaxHp;
            Root = root;
            DeactivateComponents.Instance.RemoveComponent(this);
        }

        protected virtual void Awake()
        {
            Activate(null);
        }

        public void Hurt(int damage)
        {
            Hp -= damage;
            if (Hp <= 0) 
                Deactivate();
            else if (Hp < MaxHp / 2)
                Warning();
        }

        protected virtual void Warning()
        {
                       
        }

        public virtual void Deactivate()
        {
            DeactivateComponents.Instance.AddComponent(this);
        }

    }
}