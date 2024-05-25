using UnityEngine;
namespace DevsThatJam.Food
{
    public class FoodInstance : MonoBehaviour
    {
        public FoodInfo Info { get; private set; }

        public void Init(FoodInfo info)
        {
            Info = info;
            GetComponent<SpriteRenderer>().sprite = Info.FoodSprite;
        }
    }
}

