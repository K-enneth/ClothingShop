using UnityEngine;

[CreateAssetMenu(fileName = "Clothes", menuName = "ClothingItem")]
public class Items : ScriptableObject
{
    public ClothingType clothingType;
    public Sprite icon;
    public Sprite clothingSprite;
    public int price;
}

public enum ClothingType { Shirt, Pants, Shoe }
