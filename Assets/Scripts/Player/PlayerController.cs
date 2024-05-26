using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DevsThatJam.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Transform _upLimit, _downLimit;

        [SerializeField]
        private Transform _arm;

        [SerializeField]
        private TriggerArea _triggerArea;

        private Rigidbody2D _rb;
        private float _xMov;
        private float _yMov;

        public IEnumerable<GameObject> Triggered => _triggerArea.Triggered;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = new(_xMov * 8f, _rb.velocity.y);
            _arm.localPosition = new(0f, _arm.localPosition.y + _yMov * Time.fixedDeltaTime * 2f);

            if (_arm.transform.position.y < _downLimit.position.y)
            {
                _arm.transform.position = new(_arm.transform.position.x, _downLimit.position.y);
            }

            if (_arm.transform.position.y > _upLimit.position.y)
            {
                _arm.transform.position = new(_arm.transform.position.x, _upLimit.position.y);
            }
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
