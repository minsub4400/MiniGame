using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;
    public ItemDatabase itemDatabase;

    private void Start()
    {
        
    }

    public void SetItem(Item _item)
    {
        item.itemIndex = _item.itemIndex;
        item.itemName = _item.itemName;
        item.itemType = _item.itemType;
        
        image.sprite = _item.itemImage;
    }

    public Item GetItem()
    {
        return item;
    }
}
