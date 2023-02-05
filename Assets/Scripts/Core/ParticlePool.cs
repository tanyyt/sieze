using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

namespace Core
{
    public class ParticlePool : MonoBehaviour
    {
        public static ParticlePool s_Instance;

        public static ParticlePool Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new GameObject().AddComponent<ParticlePool>();
                }

                return s_Instance;
            }
        }

        private readonly Stack<ParticleSystem> m_PlayerPool = new Stack<ParticleSystem>();
        private readonly Stack<ParticleSystem> m_EnemyPool = new Stack<ParticleSystem>();

        public void Play(IRoot root, Vector2 position)
        {
            if (root == null)
                return;
            ParticleSystem particleSystem;

            if (root is PlayerRoot)
            {
                if (m_PlayerPool.Count == 0)
                {
                    particleSystem = Instantiate(Resources.Load<ParticleSystem>($"Prefabs/ParticlePlayer"), position, Quaternion.identity);
                }
                else
                {
                    particleSystem = m_PlayerPool.Pop();
                    particleSystem.gameObject.transform.position = position;
                }

                if (!particleSystem.isPlaying)
                    particleSystem.Play();
                StartCoroutine(StopPlayerPool(particleSystem));
            }
            else
            {
                if (m_EnemyPool.Count == 0)
                {
                    particleSystem = Instantiate(Resources.Load<ParticleSystem>($"Prefabs/ParticleEnemy"), position, Quaternion.identity);
                }
                else
                {
                    particleSystem = m_EnemyPool.Pop();
                    particleSystem.gameObject.transform.position = position;
                }

                if (!particleSystem.isPlaying)
                    particleSystem.Play();
                StartCoroutine(StopEnemyPool(particleSystem));
            }
        }

        private IEnumerator StopPlayerPool(ParticleSystem particleSystem)
        {
            while (particleSystem.isPlaying)
            {
                yield return null;
            }

            m_PlayerPool.Push(particleSystem);
        }

        private IEnumerator StopEnemyPool(ParticleSystem particleSystem)
        {
            while (particleSystem.isPlaying)
            {
                yield return null;
            }

            m_EnemyPool.Push(particleSystem);
        }
    }
}