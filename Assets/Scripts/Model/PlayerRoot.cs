using Core;
using UnityEngine;
using Utils;

namespace Model
{
    public class PlayerRoot : Root
    {
        private AudioSource m_AudioSource;
        protected override void Awake()
        {
            m_AudioSource = GetComponent<AudioSource>();
            base.Awake();
            Roots.Instance.playerRoot = this;
        }

        public override void Connect(IComponent component)
        {
            m_AudioSource.Play();
            base.Connect(component);
        }

        protected override void OnDestroy()
        {
            Roots.Instance.playerRoot = null;
            EventScheduler<GameEvent>.Global[GameEvent.GameOver].Broadcast();
        }
    }
}
