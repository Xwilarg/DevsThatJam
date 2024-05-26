using UnityEngine;
namespace DevsThatJam.Food
{
    public class FoodInstance : MonoBehaviour
    {
        private FoodSpawner _foodSpawner;
        public FoodInfo Info { get; private set; }

        public void Init(FoodInfo info, FoodSpawner foodSpawner)
        {
            Info = info;
            GetComponent<SpriteRenderer>().sprite = Info.FoodSprite;
            _foodSpawner = foodSpawner;
        }
        public void SpawnFood()
        {
            _foodSpawner.SpawnFood();
        }
    }
}

