using UnityEngine;

namespace Model
{
    public interface IRoot : IEntity, IConnector
    {
        Color Color { get; }
        Color LineColor { get; }

        void RecalculateSpeed();
    }
}