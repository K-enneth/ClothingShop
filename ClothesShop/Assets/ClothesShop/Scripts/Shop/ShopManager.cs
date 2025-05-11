using System;
using System.Collections;
using ClothesShop.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject error;

    public void BuyItem(Items item)
    {
        if (inventory.coins <= item.price || inventory.playerItems.Contains(item))
        {
            StartCoroutine(ShowError());
        }
        else
        {
            inventory.AddItem(item);
        }
    }

    public void QuitShopInventory()
    {
        inventory.isShop = false;
    }

    private IEnumerator ShowError()
    {
        error.SetActive(true);
        yield return new WaitForSeconds(2f);
        error.SetActive(false);
    }
    
}
