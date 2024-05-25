using UnityEngine;
using UnityEngine.InputSystem;

namespace DevsThatJam
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private float _xMov;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = new(_xMov * 5f, _rb.velocity.y);
        }

        public void OnMove(InputAction.CallbackContext value)
        {
            _xMov = value.ReadValue<Vector2>().x;
            if (_xMov < 0f) _xMov = -1f;
            else if (_xMov > 0f) _xMov = 1f;
        }
    }
}
