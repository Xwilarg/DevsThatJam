using UnityEngine;
using UnityEngine.SceneManagement;

namespace DevsThatJam
{
    public class Persistency : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            SceneManager.LoadScene("MainMenu");
        }
    }
}
