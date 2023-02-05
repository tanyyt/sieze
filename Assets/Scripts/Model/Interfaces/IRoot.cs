using UnityEngine;

namespace Model
{
    public interface IRoot : IEntity, IConnector
    {
        Color HurtColor { get; }
        Color Color { get; }
        Color LineColor { get; }
    }
}