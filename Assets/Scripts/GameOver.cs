using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Animator _anim;

    float _inputDelay = 3f;

    bool _canInput;

    private void Awake()
    {
        _canInput = false;
        StartCoroutine(InputDelayTimer());
    }

    private void Update()
    {
        if (_canInput)
            if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene("MainMenu");

    }

    IEnumerator InputDelayTimer()
    {
        yield return new WaitForSeconds(_inputDelay);
        _canInput = true;
    }
}
