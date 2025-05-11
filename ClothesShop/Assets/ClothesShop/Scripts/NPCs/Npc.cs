using System;
using TMPro;
using UnityEngine;

namespace ClothesShop.Scripts.NPCs
{
    public class Npc : MonoBehaviour,Interfaces.IInteractable
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private GameObject icon;
        
        public virtual void Interact()
        {
        }
        

        public void ShowIcon()
        {
            icon.SetActive(true);
        }

        public void HideIcon()
        {
            icon.SetActive(false);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.TryGetComponent(out Player.Player player))
            {
                ShowIcon();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player.Player player))
            {
                HideIcon();
            }
        }
    }
}
