using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClothesShop.Scripts.Player
{
    public class Inventory : MonoBehaviour
    {
        public List<Items> playerItems = new List<Items>();
        public int coins = 100;
    
        [Header("Equipment Layers")]
        [SerializeField] private SpriteRenderer shirtLayer;
        [SerializeField] private SpriteRenderer pantsLayer;
        [SerializeField] private SpriteRenderer shoesLayer;

        public void Equip(Items clothes)
        {
            switch (clothes.clothingType)
            {
                case ClothingType.Shirt :
                    shirtLayer.sprite = clothes.clothingSprite;
                    break;
                case ClothingType.Pants :
                    pantsLayer.sprite = clothes.clothingSprite;
                    break;
                case ClothingType.Shoe :
                    shoesLayer.sprite = clothes.clothingSprite;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        
        }
    }
}
