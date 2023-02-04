using UnityEngine;

namespace Core
{
    public class CameraController : MonoBehaviour
    {
        public float smoothing;
        public Transform target;
        public bool enableCameraClamp;
        public Vector2 left_down;
        public Vector2 right_up;

        void Update()
        {
            CameraFollow();
        }

        void CameraFollow()
        {
            if (transform.position != target.position)
            {
                Vector2 targetPos = target.position;
                Vector2 curPos = transform.position;
                if (enableCameraClamp)
                {
                    targetPos.x = Mathf.Clamp(targetPos.x, left_down.x, right_up.x);
                    targetPos.y = Mathf.Clamp(targetPos.y, left_down.y, right_up.y);
                }
                var followVec = Vector2.Lerp(curPos, targetPos, smoothing);
                transform.position = new Vector3(followVec.x, followVec.y, transform.position.z);
            }
        }
    }
}