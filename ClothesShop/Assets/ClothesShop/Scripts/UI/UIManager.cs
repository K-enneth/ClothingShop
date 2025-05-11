using System;
using ClothesShop.Scripts.Player;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Player player;

    public static Action OnCloseMenu;

    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void CloseMenu()
    {
        player.EnableMovement();
        OnCloseMenu?.Invoke();
    }
}
