using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClothesShop.Scripts.Player
{
    public class Inventory : MonoBehaviour
    {
        public List<Items> playerItems = new List<Items>();
        public int coins = 100;
        public bool isShop = false;
    
        [Header("Equipment Layers")]
        [SerializeField] private SpriteRenderer shirtLayer;
        [SerializeField] private SpriteRenderer pantsLayer;
        [SerializeField] private SpriteRenderer shoesLayer;
        
        public static Action OnInventoryChanged;

        private void OnEnable()
        {
            InvSlot.OnSlotUsed += RemoveItem;
        }

        private void OnDisable()
        {
            InvSlot.OnSlotUsed -= RemoveItem;
        }

        public void AddItem(Items item)
        {
            playerItems.Add(item);
            OnInventoryChanged?.Invoke();
        }

        public void RemoveItem(Items item)
        {
            if (isShop)
            {
                Unequip(item);
                playerItems.Remove(item);
                OnInventoryChanged?.Invoke();
            }
            else
            {
                Equip(item);
            }
        }

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

        private void Unequip(Items clothes)
        {
            switch (clothes.clothingType)
            {
                case ClothingType.Shirt :
                    shirtLayer.sprite = null;
                    break;
                case ClothingType.Pants :
                    pantsLayer.sprite = null;
                    break;
                case ClothingType.Shoe :
                    shoesLayer.sprite = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
