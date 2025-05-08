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
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");
            _direction.Normalize();
            _rb.linearVelocity = _direction * speed;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.GameObject().TryGetComponent(out Interfaces.IInteractable interactable) && Input.GetKey(KeyCode.E))
            {
                interactable.Interact();
            }
        }
    }
    
}

