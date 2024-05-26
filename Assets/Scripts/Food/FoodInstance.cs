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

            FoodManager.Instance.Add(info.Type);
        }
        public void SpawnFood()
        {
            _foodSpawner.SpawnFood();
        }

        private void Update()
        {
            // OOB check
            if (transform.position.y < -10)
            {
                SpawnFood();
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            FoodManager.Instance.Remove(Info.Type);
        }
    }
}

