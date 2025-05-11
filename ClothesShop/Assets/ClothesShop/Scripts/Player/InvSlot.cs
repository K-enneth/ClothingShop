using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ClothesShop.Scripts.Player
{
    public class InvSlot : MonoBehaviour
    {
        public Image icon;
    
        [SerializeField] public Items item;

        public static Action<Items> OnSlotUsed;

        public void Setup(Items currentItem)
        {
            item = currentItem;
            icon.sprite = currentItem.icon;
        }

        public void Use()
        {
            OnSlotUsed?.Invoke(item);
        }
    
    }
}
