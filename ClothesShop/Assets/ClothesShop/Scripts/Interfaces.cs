using UnityEngine;

namespace ClothesShop.Scripts
{
    public class Interfaces : MonoBehaviour
    {
        public interface IInteractable
        {
            void Interact();
            void ShowIcon();
            void HideIcon();
        }
    }
}
