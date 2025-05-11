using ClothesShop.Scripts.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace ClothesShop.Scripts.NPCs
{
    public class ShopKeeper : MonoBehaviour,Interfaces.IInteractable
    {
        [SerializeField] private GameObject shopCanvas;
        [SerializeField] private GameObject sellCanvas;
        [SerializeField] private GameObject icon;
        [SerializeField] private GameObject player;
        public void Interact()
        {
            OpenShop();
        }
        private void OpenShop()
        {
            shopCanvas.GetComponent<Canvas>().enabled = true;
            sellCanvas.GetComponent<Canvas>().enabled = true;
            player.GetComponent<Inventory>().isShop = true;
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
            if(other.gameObject.TryGetComponent(out Player.Player user))
            {
                player = user.gameObject;
                ShowIcon();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player.Player user))
            {
                HideIcon();
            }
        }
    }
}
