using UnityEngine;

namespace Core
{
    public class Movement : MonoBehaviour
    {
        public float speed = 1f;
        public float angularSpeed = 20f;
        public float minimulAngle = 5f;
        private Rigidbody2D m_Rig;
        private Vector2 m_Direction = Vector2.zero;
        private Vector2 m_Forward = Vector2.up;

        void Awake()
        {
            m_Rig = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            m_Rig.velocity = m_Direction * speed;

            float signedAngle = Vector2.SignedAngle(new Vector2(transform.up.x, transform.up.y), new Vector2(m_Forward.x, m_Forward.y));
            m_Rig.angularVelocity = Mathf.Abs(signedAngle) > minimulAngle ? Mathf.Sign(signedAngle) * angularSpeed : 0f;
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