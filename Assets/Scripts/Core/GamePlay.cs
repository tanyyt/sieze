﻿using UnityEngine;

namespace Core
{
    public class GamePlay : MonoBehaviour
    {
        public Map map;
        private ISystem[] m_Systems;
        [SerializeField] private float m_ComponentGenerateFrequency;
        [SerializeField] private float m_EnemyRootGenerateFrequency;
        [SerializeField] private float m_MaxDeactiveComponentCount;
        [SerializeField] private float m_MaxEnemyRootCount;
        private float m_ComponentsCountdown;
        private float m_RootsCountdown;

        private ComponentsGenerator m_ComponentsGenerators;
        private EnemyRootsGenerator m_EnemyRootGenerator;

        void Awake()
        {
            m_Systems = new ISystem[]
            {
                new AttackSystem(),
                new ConnectSystem(),
            };
            m_ComponentsGenerators = new ComponentsGenerator(map);
            m_EnemyRootGenerator = new EnemyRootsGenerator(map);
        }

        void Update()
        {
            m_ComponentsCountdown += Time.deltaTime;
            m_RootsCountdown += Time.deltaTime;

            //Component Generate
            if (m_ComponentsCountdown > m_ComponentGenerateFrequency && DeactivateComponents.Instance.Count < m_MaxDeactiveComponentCount)
            {
                m_ComponentsCountdown = 0;
                m_ComponentsGenerators.Generate();
            }
            
            //Root Generate
            if (m_RootsCountdown > m_EnemyRootGenerateFrequency && Roots.Instance.Count < m_MaxEnemyRootCount)
            {
                m_RootsCountdown = 0;
                m_EnemyRootGenerator.Generate();
            }

            //Update systems
            foreach (var system in m_Systems)
            {
                system.Update(Roots.Instance);
            }
        }
    }
}