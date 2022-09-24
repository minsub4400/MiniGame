using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Item", menuName ="New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public ItemType itemType;

    public enum ItemType
    {
        Used,
        Ingredient,
    }

    public void Use()
    {
        Debug.Log("아이템 사용");
    }
}
