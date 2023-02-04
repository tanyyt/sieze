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

        public void Initialize(IRoot root)
        {
            Hp = MaxHp;
            Root = root;
        }

        protected virtual void Awake()
        {
            Initialize(null);
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