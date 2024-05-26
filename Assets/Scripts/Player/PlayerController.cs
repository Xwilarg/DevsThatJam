using DevsThatJam.Managers;
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

        [SerializeField]
        private AudioClip _upDownSfx;

        [SerializeField]
        private Animator _anim;

        private Rigidbody2D _rb;
        private float _xMov;
        private float _yMov;

        private Vector2 _startingPos;

        private AudioSource _source;
        private float _baseVolume;

        public IEnumerable<GameObject> Triggered => _triggerArea.Triggered;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();

            _source = GetComponentInChildren<AudioSource>();
            _baseVolume = _source.volume;
            _startingPos = transform.position;
        }

        private void Update()
        {
            if (transform.position.y < -10f)
            {
                transform.position = _startingPos;
                _rb.velocity = Vector2.zero;
            }
        }

        private void FixedUpdate()
        {
            if (ScoreManager.Instance.CanPlay)
            {
                _source.volume = _xMov == 0f ? 0f : _baseVolume;
                _rb.velocity = new(_xMov * 8f, _rb.velocity.y);
                _arm.localPosition = new(0f, _arm.localPosition.y + _yMov * Time.fixedDeltaTime * 4f);


            }
            else
            {
                _source.volume = 0f;
                _rb.velocity = new(0f, _rb.velocity.y);
            }

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

            var lastY = _yMov;
            _yMov = BoundOne(v2.y);


            _anim.SetFloat("xDir", _xMov);

            if (lastY != _yMov && _yMov != 0f)
            {
                AudioManager.Instance.PlayOneShot(_upDownSfx);
            }
        }
    }
}
