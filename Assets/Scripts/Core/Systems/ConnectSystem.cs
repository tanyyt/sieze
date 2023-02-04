using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

namespace Core
{
    public class ConnectSystem : ISystem
    {
        private class RootConnectorProxy : IConnectorComponent
        {
            private IRoot m_Root;

            public void SetRoot(IRoot root) => m_Root = root;

            IRoot IComponent.Root => m_Root;
            GameObject IEntity.GameObject => m_Root.GameObject;
            int IEntity.MaxHp => m_Root.MaxHp;

            int IConnector.Count => m_Root.Count;
            float IConnector.ConnectRange => m_Root.ConnectRange;

            void IConnector.Connect(IComponent component) => m_Root.Connect(component);
            void IEntity.Hurt(int damage) => m_Root.Hurt(damage);
            bool IConnector.LostConnect(IComponent component) => m_Root.LostConnect(component);

            bool IComponent.IsInConnectorRange => throw new System.NotImplementedException();

            void IComponent.Activate(IRoot root)
            {
                throw new System.NotImplementedException();
            }
            void IComponent.Deactivate()
            {
                throw new System.NotImplementedException();
            }

            void IConnector.AddComponent(IComponent component)
            {
                throw new System.NotImplementedException();
            }

            bool IConnector.RemoveComponent(IComponent component)
            {
                throw new System.NotImplementedException();
            }

            bool IConnector.RequireComponent<T>(out T component)
            {
                throw new System.NotImplementedException();
            }

            void IConnector.RequireComponents<T>(List<T> components)
            {
                throw new System.NotImplementedException();
            }

            IEnumerator<IComponent> IEnumerable<IComponent>.GetEnumerator()
            {
                throw new System.NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new System.NotImplementedException();
            }
        }

        private List<IConnectorComponent> m_List = new List<IConnectorComponent>();
        private RootConnectorProxy m_Cache = new RootConnectorProxy();
        private KeyCode m_KeyCode;

        public ConnectSystem(KeyCode code)
        {
            m_KeyCode = code;
        }

        public void Update(Roots roots)
        {
            foreach(var root in roots)
            {
                if (!ReferenceEquals(root, Roots.Instance.playerRoot))
                {
                    continue;
                }

                if(UnityEngine.Input.GetKeyDown(m_KeyCode))
                {
                    root.RequireComponents(m_List);
                    m_Cache.SetRoot(root);
                    m_List.Add(m_Cache);
                    var cachedDeactiveComponents = DeactivateComponents.Instance.GetCloneList();
                    foreach (var component in cachedDeactiveComponents)
                    {
                        if(!component.IsInConnectorRange)
                        {
                            continue;
                        }

                        float minMag = float.MaxValue;
                        IConnectorComponent minMagConnector = null;
                        foreach (var connector in m_List)
                        {
                            float mag = (component.GameObject.transform.position - connector.GameObject.transform.position).magnitude;
                            if(mag < connector.ConnectRange && mag < minMag)
                            {
                                minMag = mag;
                                minMagConnector = connector;
                            }
                        }

                        if(null != minMagConnector)
                        {
                            minMagConnector.Connect(component);
                        }
                    }
                }
            }
        }
    }
}
