using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public string itemName;
    public Sprite itemImage;

    public void Use()
    {
        Debug.Log("아이템 사용");
    }
}
