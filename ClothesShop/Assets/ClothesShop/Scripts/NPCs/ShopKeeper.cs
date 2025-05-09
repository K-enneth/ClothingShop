using UnityEngine;

namespace ClothesShop.Scripts.NPCs
{
    public class ShopKeeper : MonoBehaviour,Interfaces.IInteractable
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] private GameObject icon;
        public void Interact()
        {
            OpenShop();
        }
        private void OpenShop()
        {
            canvas.GetComponent<Canvas>().enabled = true;
            Debug.Log("Open Shop");
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
