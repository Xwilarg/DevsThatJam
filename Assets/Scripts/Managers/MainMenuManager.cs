using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace DevsThatJam.Managers
{
    public class MainMenuManager : MonoBehaviour
    {

        [SerializeField] GameObject _instructionScreen;

        [SerializeField] SceneAsset _gameScene;

        [SerializeField] Animator _anim;

        float _delay;

        private void Awake()
        {
            _delay = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_instructionScreen.activeSelf && _delay < 0f)
                    _instructionScreen.SetActive(false);
                else
                    _anim.SetTrigger("Open");
            }
            _delay -= Time.deltaTime;
        }

        public void DisplayInstructions()
        {
            _instructionScreen.SetActive(true);
            _delay = 0.5f;
        }

        public void StartGame()
        {
            SceneManager.LoadScene(_gameScene.name);
        }
    }
}