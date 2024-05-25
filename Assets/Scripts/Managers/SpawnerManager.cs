using UnityEngine;
namespace DevsThatJam.Managers
{
    public class SpawnerManager : MonoBehaviour
    {
        [SerializeField] private FoodInfo[] _foodList;
        [SerializeField] private GameObject _foodPrefab;
        public static SpawnerManager Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
        }
        
        public FoodInfo GetRandomFood()
        {
            return _foodList[Random.Range(0, _foodList.Length)];
        }
        
        public GameObject GetPrefab()
        {
            return _foodPrefab;
        }
    }
}

