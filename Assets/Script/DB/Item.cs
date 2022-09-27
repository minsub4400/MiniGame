using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ItemType
{
    Used,
    Ingredient,
}

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemImage;
    public int itemIndex;
    public ItemType itemType;

    public void Use()
    {
        Debug.Log("아이템 사용");
    }
}
