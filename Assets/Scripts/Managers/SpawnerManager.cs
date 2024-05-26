using DevsThatJam.Enums;
using System.Linq;
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
        
        public FoodInfo GetRandomFood(FoodTypes except)
        {
            var list = _foodList.Where(x => x.Type != except).ToArray();
            return list[Random.Range(0, list.Length)];
        }
        
        public GameObject GetPrefab()
        {
            return _foodPrefab;
        }
    }
}

