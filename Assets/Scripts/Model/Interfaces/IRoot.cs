using System.Collections.Generic;

namespace Model
{
    public interface IRoot : IEntity, IConnector, IEnumerable<IComponent>
    {
        void AddComponent(IComponent component);
        bool RemoveComponent(IComponent component);
    }
}