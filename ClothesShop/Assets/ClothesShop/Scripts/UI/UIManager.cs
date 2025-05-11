using System;
using System.Collections.Generic;
using ClothesShop.Scripts.Player;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Player player;
    
    [Header("Inventory UI")]
    public Inventory inventory;
    public Transform container;
    public GameObject slotPrefab;
    private List<Items> _currentItems = new List<Items>();

    public static Action OnCloseMenu;

    public void OnEnable()
    {
        Inventory.OnInventoryChanged += UpdateInventory;
    }

    public void OnDisable()
    {
        Inventory.OnInventoryChanged -= UpdateInventory;
    }

    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        var ownedItems = inventory.playerItems;
        for (int i = _currentItems.Count - 1; i >= 0; i--)
        {
            if (!ownedItems.Contains(_currentItems[i]))
            {
                foreach (Transform child in container)
                {
                    var slot = child.GetComponent<InvSlot>();
                    if (slot != null && slot.item == _currentItems[i])
                    {
                        Destroy(child.gameObject);
                        break;
                    }
                }
                _currentItems.RemoveAt(i);
            }
        }

        for (var indexItem = 0; indexItem < ownedItems.Count; indexItem++)
        {
            var item = ownedItems[indexItem];
            if (!_currentItems.Contains(item))
            {
                GameObject slot = Instantiate(slotPrefab, container);
                slot.GetComponent<InvSlot>().Setup(item);
                _currentItems.Add(item);
            }
        }
    }

    public void CloseMenu(Canvas canvas)
    {
        canvas.GetComponent<Canvas>().enabled = false;
        player.EnableMovement();
        OnCloseMenu?.Invoke();
    }
}
