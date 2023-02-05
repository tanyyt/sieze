using UnityEngine;

namespace Core
{
    public class Movement : MonoBehaviour
    {
        public float speed = 1f;
        public float angularSpeed = 20f;
        public float minimulAngle = 5f;

        private float m_ActualSpeed;
        private float m_ActualAngularSpeed;
        private Rigidbody2D m_Rig;
        private Vector2 m_Direction = Vector2.zero;
        private Vector2 m_Forward = Vector2.up;

        void Awake()
        {
            m_Rig = GetComponent<Rigidbody2D>();
            m_ActualSpeed = speed;
            m_ActualAngularSpeed = angularSpeed;
        }

        void FixedUpdate()
        {
            m_Rig.velocity = m_Direction * m_ActualSpeed;

            float signedAngle = Vector2.SignedAngle(new Vector2(transform.up.x, transform.up.y), new Vector2(m_Forward.x, m_Forward.y));
            m_Rig.angularVelocity = Mathf.Abs(signedAngle) > minimulAngle ? Mathf.Sign(signedAngle) * m_ActualAngularSpeed : 0f;
        }

        public void SetSpeedRate(float rate)
        {
            m_ActualSpeed = rate * speed;
            m_ActualAngularSpeed = rate * angularSpeed;
        }

        public void SetDirection(Vector2 dir)
        {
            m_Direction = dir.normalized;
        }

        public void SetForward(Vector2 forward)
        {
            m_Forward = forward.normalized;
        }
    }
}