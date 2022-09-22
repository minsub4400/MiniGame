using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public GameObject ItemImage;
    private Image itemIcon;

    private void Awake()
    {
        itemIcon = ItemImage.GetComponent<Image>();
    }

    public void UpdateSlotUI(int index)
    {
        //Debug.Log($"{ItemDB.instance.itemDB[i].itemImage.name}");
        //itemIcon.sprite = item.itemImage;
        itemIcon.sprite = ItemDB.instance.itemDB[index].itemImage;
    }
}
