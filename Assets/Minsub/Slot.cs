using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class Slot : MonoBehaviour
{
    public Item item;
    public int itemCount;
    public Image itemImage;

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_ConutImage;

    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        go_ConutImage.SetActive(true);
        text_Count.text = itemCount.ToString();

        SetColor(1);
    }

    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_ConutImage.SetActive(false);
    }


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
