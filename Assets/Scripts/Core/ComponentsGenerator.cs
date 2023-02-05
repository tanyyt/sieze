using Model;
using UnityEngine;

namespace Core
{
    public class ComponentsGenerator : EntityGenerator
    {
        private string[] m_ComponentNames;
        private int m_MaxGenerateCount = 5;
        private int m_GeneratedCount = 0;

        public ComponentsGenerator(Map map) : base(map)
        {
            m_ComponentNames = new string[]
            {
                "Shooter",
                "Connector",
                "FixedShooter",
            };
        }

        protected override void OnGenerate(Vector2 pos)
        {
            if(m_GeneratedCount >= m_MaxGenerateCount)
            {
                return;
            }

            var index = Random.Range(0, m_ComponentNames.Length);
            var componentName = m_ComponentNames[index];
            var gameObject = Object.Instantiate(Resources.Load<GameObject>($"Prefabs/{componentName}"), pos, Quaternion.identity);
            DeactivateComponents.Instance.AddComponent(gameObject.GetComponent<IComponent>());
            m_GeneratedCount++;
        }
    }
}