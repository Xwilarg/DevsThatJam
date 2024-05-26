using DevsThatJam.Managers;
using TMPro;
using UnityEngine;

namespace DevsThatJam
{
    public class UpdateTextWithScore : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<TMP_Text>().text += $"{ScoreManager.FinalScore}";
        }
    }
}