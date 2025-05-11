using System;
using Unity.VisualScripting;
using UnityEngine;

namespace ClothesShop.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        public float speed;
        private Rigidbody2D _rb;
        private Vector2 _direction;
        private bool _canMove = true;

        [Header("Interact")] 
        private Interfaces.IInteractable _currentInteractable;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_canMove) return;
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");
            _direction.Normalize();
            _rb.linearVelocity = _direction * speed;
            
            if (Input.GetKeyDown(KeyCode.E) && _currentInteractable != null)
            {
                _currentInteractable.Interact();
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

        public void EnableMovement()
        {
            _canMove = true;
        }
    }
    
}

