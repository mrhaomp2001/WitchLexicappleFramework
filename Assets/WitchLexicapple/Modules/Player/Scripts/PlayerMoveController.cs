using UnityEngine;
using UnityEngine.InputSystem;

namespace MysticalDreamers.WitchLexicapple
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField] private InputActionReference moveAction;

        private Rigidbody2D rb;
        private Vector2 moveInput;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            if (moveAction == null)
            {
                Debug.LogWarning($"{nameof(PlayerMoveController)}: {nameof(moveAction)} is not assigned.", this);
                return;
            }

            moveAction.action.Enable();
        }

        private void OnDisable()
        {
            if (moveAction == null)
                return;

            moveAction.action.Disable();
        }

        private void Update()
        {
            if (moveAction == null)
                return;

            moveInput = moveAction.action.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            var speed = StatManager.GetStat(StatKey.Speed);
            rb.linearVelocity = moveInput * speed;
        }
    }
}
