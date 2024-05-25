using DevsThatJam.Food;
using DevsThatJam.Managers;
using UnityEngine;
namespace DevsThatJam.Monster
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField] GameObject _thoughtBubble, _thoughtPoint;
        private FoodInfo _chosenFood;

        private void Start()
        {
            _chosenFood = SpawnerManager.Instance.GetRandomFood();
            CreateThoughtBubble();
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Food"))
            {
                if (FoodValidation(collision.GetComponent<FoodInstance>().Info))
                {
                    Destroy(collision.gameObject);
                }
            }
        }
        private void CreateThoughtBubble()
        {
            // Create a clone with the current thought bubble
            GameObject thoughtClone = Instantiate(_thoughtBubble, _thoughtPoint.transform);
            // Grab SpriteRenderer of the thought clone
            var sr = thoughtClone.GetComponentsInChildren<SpriteRenderer>()[1];
            // Set the chosen food sprite
            sr.sprite = _chosenFood.FoodSprite;
            // Set sprite to black for sillouette
            sr.color = Color.black;
        }

        private bool FoodValidation(FoodInfo foodInfo)
        {
            return foodInfo == _chosenFood;
        }

    }
}

