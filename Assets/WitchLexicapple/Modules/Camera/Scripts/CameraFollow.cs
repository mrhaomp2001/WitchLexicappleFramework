using UnityEngine;

namespace MysticalDreamers.WitchLexicapple
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new(0f, 0f, -10f);
        [SerializeField] private float smoothTime = 0.15f;

        private Vector3 velocity;

        private void OnEnable()
        {
            if (target == null)
                Debug.LogWarning($"{nameof(CameraFollow)}: {nameof(target)} is not assigned.", this);
        }

        private void LateUpdate()
        {
            if (target == null)
                return;

            var desiredPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        }
    }
}
