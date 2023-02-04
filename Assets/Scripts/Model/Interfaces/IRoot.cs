using System.Collections.Generic;

namespace Model
{
    public interface IRoot : IEntity, IConnector, IEnumerable<IComponent>
    {
        int Count { get; }
        void AddComponent(IComponent component);
        bool RemoveComponent(IComponent component);
        bool RequireComponent<T>(out T component) where T : IComponent;
    }
}