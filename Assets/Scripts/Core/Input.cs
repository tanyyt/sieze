using UnityEngine;

namespace Core
{
    public class Input : MonoBehaviour
    {
        public Movement movement;
        public KeyCode left;
        public KeyCode right;

        void Update()
        {
            if(GamePlay.isGameOver)
            {
                return;
            }

            var horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
            var vertical = UnityEngine.Input.GetAxisRaw("Vertical");
            movement.SetDirection(Vector3.right * horizontal + Vector3.up * vertical);

            //var targetPos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            //movement.SetForward(targetPos - transform.position);
            if(UnityEngine.Input.GetKey(left))
            {
                movement.SetForward(Quaternion.AngleAxis(5f, Vector3.forward) * transform.up);
            }

            if(UnityEngine.Input.GetKey(right))
            {
                movement.SetForward(Quaternion.AngleAxis(-5f, Vector3.forward) * transform.up);
            }
        }
    }
}
