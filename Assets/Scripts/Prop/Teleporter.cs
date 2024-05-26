using System.Collections;
using UnityEngine;

namespace DevsThatJam.Prop
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField]
        private Teleporter _teleportationTarget;

        [SerializeField]
        private Sprite _spriteOn, _spriteOff;

        [SerializeField]
        private Transform _outPoint;
        public Vector3 OutPos => _outPoint.position;

        private SpriteRenderer _sr;

        private PlayerController _target;

        private bool _isReloading;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            _sr.sprite = _spriteOn;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _target = collision.GetComponent<PlayerController>();
                if (!_isReloading)
                {
                    Teleport();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _target = null;
            }
        }

        private void Teleport()
        {
            _target.transform.position = _teleportationTarget.OutPos;
            StartCoroutine(_teleportationTarget.Reload());
        }

        private IEnumerator Reload()
        {
            _isReloading = true;
            _sr.sprite = _spriteOff;
            yield return new WaitForSeconds(3f);
            _isReloading = false;
            _sr.sprite = _spriteOn;
            if (_target != null)
            {
                Teleport();
            }
        }
    }
}
