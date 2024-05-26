using DevsThatJam.Food;
using DevsThatJam.Managers;
using UnityEngine;
namespace DevsThatJam.Monster
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField] GameObject _thoughtBubble, _thoughtPoint;
        private FoodInfo _chosenFood;

        [SerializeField]
        private AudioClip _munchSfx;

        private GameObject _bubbleFood;

        private void Start()
        {
            CreateNeed();
        }

        private void CreateNeed()
        {
            var prev = _chosenFood?.Type ?? (Enums.FoodTypes)(-1);
            _chosenFood = SpawnerManager.Instance.GetRandomFood(prev);
            CreateThoughtBubble();
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Food") && ScoreManager.Instance.CanPlay)
            {
                var foodInstance = collision.transform.parent.GetComponent<FoodInstance>();
                if (FoodValidation(foodInstance.Info))
                {
                    ScoreManager.Instance.IncreaseScore(5);
                }
                else
                {
                    ScoreManager.Instance.DecreaseScore(1);
                }
                AudioManager.Instance.PlayOneShot(_munchSfx);
                foodInstance.SpawnFood();
                Destroy(foodInstance.gameObject);
                CreateNeed();
            }
        }
        private void CreateThoughtBubble()
        {
            if (_bubbleFood != null)
            {
                Destroy(_bubbleFood);
            }

            // Create a clone with the current thought bubble
            _bubbleFood = Instantiate(_thoughtBubble, _thoughtPoint.transform);
            // Grab SpriteRenderer of the thought clone
            var sr = _bubbleFood.GetComponentsInChildren<SpriteRenderer>()[1];
            sr.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            // Set the chosen food sprite
            sr.sprite = _chosenFood.FoodSprite;
            // Set sprite to black for silhouette
            sr.color = Color.black;
        }

        private bool FoodValidation(FoodInfo foodInfo)
        {
            return foodInfo == _chosenFood;
        }

    }
}

