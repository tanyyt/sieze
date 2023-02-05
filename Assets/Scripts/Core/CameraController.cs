using System;
using UnityEngine;

namespace Core
{
    public class CameraController : MonoBehaviour
    {
        public float smoothTime = 1f;
        public Transform target;
        [SerializeField]
        private Animator m_Animator;

        private void Awake()
        {
            GameEvent.cameraHugeShake += HugeShake;
            GameEvent.cameraShortShake += ShortShake;
        }

        private void ShortShake()
        {
            if (GamePlay.isGameOver)
                return;
            if (null != m_Animator)
            {
                m_Animator.Play("ShortShake");
            }
        }

        private void HugeShake()
        {
            if (GamePlay.isGameOver)
                return;
            if(null != m_Animator)
            {
                m_Animator.Play("Shake");
            }
        }

        void FixedUpdate()
        {
            if (target != null)
            {
                CameraFollow();
            }
        }

        void CameraFollow()
        {
            if (transform.position != target.position)
            {
                Vector2 targetPos = target.position;
                Vector2 curPos = transform.position;

                var curVel = Vector2.zero;
                var followVec = Vector2.SmoothDamp(curPos, targetPos, ref curVel, smoothTime, Mathf.Infinity, Time.fixedDeltaTime);
                transform.position = new Vector3(followVec.x, followVec.y, transform.position.z);
            }
        }
    }
}