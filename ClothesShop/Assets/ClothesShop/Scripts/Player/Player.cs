using System;
using ClothesShop.Scripts.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace ClothesShop.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        public float speed;
        private Rigidbody2D _rb;
        private Vector2 _direction;
        private bool _canMove = true;

        [Header("Inventory")]
        [SerializeField] private Canvas inventory;
        [SerializeField] private bool inventoryOpen;
        
        [Header("Interact")] 
        private Interfaces.IInteractable _currentInteractable;
        
        private void OnEnable()
        {
            UIManager.OnCloseMenu += EnableMovement;
        }

        private void OnDisable()
        {
            UIManager.OnCloseMenu -= EnableMovement;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryUI(inventoryOpen);
            }
            
            if (!_canMove) return;
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");
            _direction.Normalize();
            _rb.linearVelocity = _direction * speed;
            
            if (Input.GetKeyDown(KeyCode.E) && _currentInteractable != null)
            {
                _currentInteractable.Interact();
                DisableMovement();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GameObject().TryGetComponent(out Interfaces.IInteractable interactable))
            {
                _currentInteractable = interactable;
            }
        }
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Interfaces.IInteractable interactable) && interactable == _currentInteractable)
            {
                _currentInteractable = null;
            }
        }

        private void InventoryUI(bool isOpen)
        {
            if (!isOpen)
            {
                if (!_canMove) return;
                inventory.GetComponent<Canvas>().enabled = true;
                inventoryOpen = true;
                DisableMovement();
            }
            else
            {
                inventory.GetComponent<Canvas>().enabled = false;
                inventoryOpen = false;
                EnableMovement();
            }
        }

        public void EnableMovement()
        {
            _canMove = true;
        }

        public void DisableMovement()
        {
            _rb.linearVelocity = Vector2.zero;
            _canMove = false;
        }
    }
    
}

