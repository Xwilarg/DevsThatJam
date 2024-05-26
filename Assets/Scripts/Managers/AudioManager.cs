using UnityEngine;

namespace DevsThatJam.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { private set; get; }

        private AudioSource _source;

        private void Awake()
        {
            Instance = this;
            _source = GetComponentInChildren<AudioSource>();
        }

        public void PlayOneShot(AudioClip clip)
        {
            _source.PlayOneShot(clip);
        }
    }
}