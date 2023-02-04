using Model;
using UnityEngine;

namespace Core
{
    public class ComponentsGenerator : EntityGenerator
    {
        private string[] m_ComponentNames;

        public ComponentsGenerator(Map map) : base(map)
        {
            m_ComponentNames = new string[]
            {
                "Shooter"
            };
        }

        protected override void OnGenerate(Vector2 pos)
        {
            var index = Random.Range(0, m_ComponentNames.Length - 1);
            var componentName = m_ComponentNames[index];
            var gameObject = Object.Instantiate(Resources.Load<GameObject>($"Prefabs/{componentName}"), pos, Quaternion.identity);
            DeactivateComponents.Instance.AddComponent(gameObject.GetComponent<IComponent>());
        }
    }
}