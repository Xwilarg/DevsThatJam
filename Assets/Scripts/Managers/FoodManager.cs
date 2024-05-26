using DevsThatJam.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace DevsThatJam
{
    public class FoodManager : MonoBehaviour
    {
        public static FoodManager Instance { private set; get; }

        private Dictionary<FoodTypes, int> _foods = new();

        private void Awake()
        {
            Instance = this;
        }

        public void Add(FoodTypes type)
        {
            if (_foods.ContainsKey(type))
            {
                _foods[type]++;
            }
            else
            {
                _foods.Add(type, 1);
            }
        }

        public void Remove(FoodTypes type)
        {
            _foods.Remove(type);
        }

        public int Get(FoodTypes type)
            => _foods.ContainsKey(type) ? _foods[type] : 0;
    }
}