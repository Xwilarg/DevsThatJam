using DevsThatJam.Managers;
using UnityEngine;
namespace DevsThatJam.Food
{
    public class FoodSpawner : MonoBehaviour
    {
        private void Start()
        {
            SpawnFood();
        }
        public void SpawnFood()
        {
            var foodSpawned = SpawnerManager.Instance.GetRandomFood();
            var foodClone = Instantiate(SpawnerManager.Instance.GetPrefab(), transform.position, Quaternion.identity);
            foodClone.GetComponent<FoodInstance>().Init(foodSpawned, this);
            var colliderClone = Instantiate(foodSpawned.ColliderPrefab, foodClone.transform);
        }
    }
}

