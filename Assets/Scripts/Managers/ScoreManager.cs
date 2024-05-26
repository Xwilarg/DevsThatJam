using UnityEngine;

namespace DevsThatJam.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score;
        private float _timeSize;
        private bool _isTimerActive = false;
        public static ScoreManager Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
        }

        public void IncreaseScore(int increment) => _score += increment;

        public void DecreaseScore(int decrement) => _score -= decrement;

        public int GetScore() => _score;

        public float StartTimer(float timeValue)
        {
            _timeSize = timeValue;
            _isTimerActive = true;
            return _timeSize;
        }

        private void ExecuteTimer()
        {
            if(_timeSize >= 0f) _timeSize -= Time.deltaTime;
            else _isTimerActive = false;
        }

        private void Update()
        {
            if (_isTimerActive) ExecuteTimer();
        }

    }
    
}
