using System.Collections.Generic;
using UnityEngine;

namespace DevsThatJam.Player
{
    public class TriggerArea : MonoBehaviour
    {
        private List<GameObject> _triggered = new();

        public IEnumerable<GameObject> Triggered => _triggered;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _triggered.Add(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _triggered.Remove(collision.gameObject);
        }
    }
}