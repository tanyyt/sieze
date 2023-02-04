using UnityEngine;

namespace Model
{
    public interface IEntity
    {
        GameObject GameObject { get;}
        int MaxHp { get; }
        void Hurt(int damage);
    }
}