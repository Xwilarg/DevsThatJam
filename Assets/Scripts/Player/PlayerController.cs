using UnityEngine;
using UnityEngine.InputSystem;

namespace DevsThatJam
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Transform _upLimit, _downLimit;

        [SerializeField]
        private Transform _arm;

        private Rigidbody2D _rb;
        private float _xMov;
        private float _yMox;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = new(_xMov * 5f, _rb.velocity.y);
        }

        private float BoundOne(float value)
        {
            if (value < 0f) value = -1f;
            else if (value > 0f) value = 1f;
            return value;
        }

        public void OnMove(InputAction.CallbackContext value)
        {
            _xMov = BoundOne(value.ReadValue<Vector2>().x);
        }
    }
}
