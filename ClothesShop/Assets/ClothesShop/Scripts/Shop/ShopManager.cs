using System;
using ClothesShop.Scripts.Player;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Canvas shopCanvas;


    private void Start()
    {
        shopCanvas = GetComponent<Canvas>();
    }

    public void BuyItem(Items item)
    {
        inventory.Equip(item);
    }

    public void SellItem(Items item)
    {
        
    }
    
    
}
