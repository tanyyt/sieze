using UnityEngine;

namespace Core
{
    public class Input : MonoBehaviour
    {
        public Movement movement;

        void Update()
        {
            var horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
            var vertical = UnityEngine.Input.GetAxisRaw("Vertical");
            movement.SetDirection(Vector3.right * horizontal + Vector3.up * vertical);

            var targetPos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            movement.SetForward(targetPos - transform.position);
        }
    }
}
