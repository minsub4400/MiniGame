using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class Slot : MonoBehaviour
{
    public Sprite itemIcon;
    public int itemIndex;
    public int itemCount;

    private Image itemImage;
    public Transform itemImageSprite;

    // 하위 오브젝트
    private SlotImage slotImage;
    private SlotText slotText;

    private void Awake()
    {
        slotImage = GetComponentInChildren<SlotImage>();
        slotText = GetComponentInChildren<SlotText>();

    }

    public void UpdateSlotImageUI(Sprite _itemImage)
    {
        itemIcon = _itemImage;
        slotImage.SetImage(itemIcon);
    }

    public void UpdateSlotTextUI(int _itemCount)
    {
        itemCount = _itemCount;
        slotText.SetText(itemCount);
    }
    /*public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }*/


    /*public Item item;
    public GameObject ItemImage;
    private Image itemIcon;
    private Text textMeshProUGUI;
    private Inventory inventory;

    private void Awake()
    {
        itemIcon = ItemImage.GetComponent<Image>();
        textMeshProUGUI = GetComponentInChildren<Text>();
        inventory = GetComponentInParent<Inventory>();
    }


    //private List<int> itemCount;
    private int itemCount;
    //private int itemCount;
    public void UpdateSlotUI(int index, int slotNumber)
    {
        //Debug.Log($"{ItemDB.instance.itemDB[i].itemImage.name}");
        //itemIcon.sprite = item.itemImage;
        //Debug.Log(ItemDB.instance.itemDB[index].itemImage);

        itemIcon.sprite = ItemDB.instance.itemDB[index].itemImage;
        //itemCount = Inventory.inventory.item_dic[ItemDB.instance.itemDB[index].itemName];
        itemCount = inventory.item_dic.Values.ElementAt(slotNumber);
        //itemCount = inventory.item_dic[ItemDB.instance.itemDB[index].itemName];
        *//*Debug.Log(inventory.item_dic.Values.ElementAt(slotNumber));
        Debug.Log(slotNumber);
        Debug.Log(itemCount[slotNumber].ToString());*//*
        //textMeshProUGUI.text = itemCount[slotNumber].ToString();
        textMeshProUGUI.text = itemCount.ToString();
        //textMeshProUGUI.text = inventory.item_dic.Values.ElementAt(slotNumber).ToString();
        //inventory.slotNumber += 1;
    }

    public void UpdateSlotTextCountUI(int index, int index_dic)
    {
        //itemCount = inventory.item_dic.Values.ElementAt(index_dic);
        itemCount = inventory.item_dic.Values.ElementAt(index_dic);
        //itemCount = Inventory.inventory.item_dic[ItemDB.instance.itemDB[index].itemName];
        //Debug.Log(itemCount[index]);
        textMeshProUGUI.text = itemCount.ToString();
        //textMeshProUGUI.text = itemCount[index_dic].ToString();
    }*/
}
