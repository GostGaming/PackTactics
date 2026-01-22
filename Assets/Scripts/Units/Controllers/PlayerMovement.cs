using UnityEngine;
using UnityEngine.InputSystem;

namespace Units.Controllers {
    public class PlayerMovement : MonoBehaviour {
        private Rigidbody2D _rigidbody;
        private Vector2 _moveInput;

        private Vector2 _startPos; // Starting position of character before movement is made
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
//            _rigidbody.linearVelocity = _moveInput * moveSpeed;
        }

        public void Move(InputAction.CallbackContext context) {
//            _moveInput = context.ReadValue<Vector2>();
        }
    }
}
