using System;
using UnityEngine;

namespace ClothesShop.Scripts.NPCs
{
    public class Npc : MonoBehaviour,Interfaces.IInteractable
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private GameObject icon;
        
        public void Interact()
        {
            OpenDialogue();
        }

        public void ShowIcon()
        {
            icon.SetActive(true);
        }

        private void HideIcon()
        {
            icon.SetActive(false);
        }

        private void OpenDialogue()
        {
            Debug.Log("Opening Dialogue");
            //canvas.gameObject.GetComponent<Canvas>().enabled = true;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.TryGetComponent(out Player.Player player))
            {
                Debug.Log("Player entered NPC");
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
