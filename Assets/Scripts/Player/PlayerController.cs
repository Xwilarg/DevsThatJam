using UnityEngine;
using UnityEngine.InputSystem;

namespace DevsThatJam
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Transform _upLimit, _downLimit;

        [SerializeField]
        private Rigidbody2D _arm;

        private Rigidbody2D _rb;
        private float _xMov;
        private float _yMov;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = new(_xMov * 5f, _rb.velocity.y);
            _arm.velocity = new(0f, _yMov);

            if (_arm.transform.position.y < _downLimit.position.y) _arm.transform.position = new(_arm.transform.position.x, _downLimit.position.y);
            if (_arm.transform.position.y > _upLimit.position.y) _arm.transform.position = new(_arm.transform.position.x, _upLimit.position.y);
        }

        private float BoundOne(float value)
        {
            if (value < 0f) value = -1f;
            else if (value > 0f) value = 1f;
            return value;
        }

        public void OnMove(InputAction.CallbackContext value)
        {
            var v2 = value.ReadValue<Vector2>();
            _xMov = BoundOne(v2.x);
            _yMov = BoundOne(v2.y);
        }
    }
}
