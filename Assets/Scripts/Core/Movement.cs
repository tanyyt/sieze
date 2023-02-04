using UnityEngine;

namespace Core
{
    public class Movement : MonoBehaviour
    {
        public float speed = 1;
        private Rigidbody2D m_Rig;
        void Awake()
        {
            m_Rig = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            m_Rig.velocity = (transform.right * horizontal + transform.up * vertical).normalized * (speed * 100 * Time.deltaTime);
        }
    }
}