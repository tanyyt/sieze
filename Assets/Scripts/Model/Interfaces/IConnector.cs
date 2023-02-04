using System.Collections.Generic;

namespace Model
{
    public interface IConnector : IEnumerable<IComponent>
    {
        void Connect(IComponent component);
        bool LostConnect(IComponent component);

        int Count { get; }
        void AddComponent(IComponent component);
        bool RemoveComponent(IComponent component);
        bool RequireComponent<T>(out T component) where T : IComponent;
        void RequireComponents<T>(List<T> components) where T : IComponent;
    }
}