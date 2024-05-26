using DevsThatJam.Food;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace DevsThatJam
{
    [CreateAssetMenu(fileName = "Foodtype", menuName = "Scriptable Objects/Foodtype")]
    public class FoodInfo : ScriptableObject
    {
        public Enums.FoodTypes Type;
        public Sprite FoodSprite;
        public GameObject ColliderPrefab;
        public static bool operator ==(FoodInfo a, FoodInfo b)
        {
            if(a is null)
            {
                return b is null;
            }
            if(b is null)
            {
                return false;
            }
            return a.Type == b.Type;
        }
        public static bool operator !=(FoodInfo a, FoodInfo b)
        {
            return !(a.Type == b.Type);
        }

        public override bool Equals(object obj)
        {
            if (obj is FoodInfo info) return this == info;
            return false;
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }
    }
}

