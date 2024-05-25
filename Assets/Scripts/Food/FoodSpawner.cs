using DevsThatJam.Managers;
using UnityEngine;
namespace DevsThatJam.Food
{
    public class FoodSpawner : MonoBehaviour
    {
        private void Start()
        {
            var foodSpawned = SpawnerManager.Instance.GetRandomFood();
            var foodClone = Instantiate(SpawnerManager.Instance.GetPrefab(), transform.position, Quaternion.identity);
            foodClone.GetComponent<FoodInstance>().Init(foodSpawned);
        }
    }
}

