using UnityEngine;

namespace Core
{
    public class Movement : MonoBehaviour
    {
        public Map map;
        public float speed = 1f;
        public float angularSpeed = 20f;
        public float minimulAngle = 5f;
        private Rigidbody2D m_Rig;

        void Awake()
        {
            m_Rig = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            m_Rig.velocity = (Vector3.right * horizontal + Vector3.up * vertical).normalized * speed;

            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var targetDir = (targetPos - transform.position).normalized;
            float signedAngle = Vector2.SignedAngle(new Vector2(transform.up.x, transform.up.y), new Vector2(targetDir.x, targetDir.y));
            m_Rig.angularVelocity = Mathf.Abs(signedAngle) > minimulAngle ? Mathf.Sign(signedAngle) * angularSpeed : 0f;
        }
    }
}