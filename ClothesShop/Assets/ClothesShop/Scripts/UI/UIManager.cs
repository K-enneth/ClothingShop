using System;
using ClothesShop.Scripts.Player;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Player player;
    
    [Header("Inventory UI")]
    public Inventory inventory;
    public Transform container;
    public GameObject slotPrefab;

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
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in inventory.playerItems)
        {
            var slot = Instantiate(slotPrefab, container);
            slot.GetComponent<InvSlot>().Setup(item);
        }
    }

    public void CloseMenu(Canvas canvas)
    {
        canvas.GetComponent<Canvas>().enabled = false;
        player.EnableMovement();
        OnCloseMenu?.Invoke();
    }
}
