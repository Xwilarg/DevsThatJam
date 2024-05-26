using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace DevsThatJam.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score;
        private float _timeSize;
        private bool _isTimerActive = false;
        [SerializeField] private TextMeshProUGUI _scoreText, _timerText;

        public static int FinalScore = 0;
        public static ScoreManager Instance { private set; get; }

        public bool CanPlay => _isTimerActive;

        private void Awake()
        {
            Instance = this;
            StartTimer(60f);
        }

        public void IncreaseScore(int increment) { _score += increment; UpdateScore(); }

        public void DecreaseScore(int decrement) { _score -= decrement; UpdateScore(); }

        public void UpdateScore() { _scoreText.text = _score.ToString(); }

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
            else
            {
                _isTimerActive = false;
                FinalScore = _score;
                SceneManager.LoadScene("GameOver");
            }
        }

        private void Update()
        {
            if (_isTimerActive) ExecuteTimer();
            _timerText.text = ((int)_timeSize).ToString();
        }

    }
    
}
