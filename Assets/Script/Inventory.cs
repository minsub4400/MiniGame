using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;

    // 아이템 획득하면 담을 리스트
    public List<Item> items = new List<Item>();

    // 아이템 갯수를 담을 리스트
    public List<Item> itemCounts = new List<Item>();

    public Dictionary<string, int> item_dic = new Dictionary<string, int>();

    // 아이템 갯수 컴포넌트를 담을 변수
    private PickUpItemText itemCount;
    public Slot[] slots;

    private void Awake()
    {
        itemCount = GameObject.Find("Canvas").transform.Find("PickUpItemText").GetComponent<PickUpItemText>();
    }

    public void AddItem(int itemNumber)
    {
        //items.Add(ItemDB.instance.itemDB[itemNumber]);

        item_dic.Add(ItemDB.instance.itemDB[itemNumber].itemName, itemCount.itemCount);
        DrawItemUI(itemNumber);
        //Debug.Log(itemCount.itemCount);
    }

    // 슬롯의 인덱스를 지정할 변수
    private int slotNumber = 0;

    public void DrawItemUI(int itemNumber)
    {
        slots[slotNumber].item = ItemDB.instance.itemDB[itemNumber];
        //slots[slotNumber].item = items[slotNumber];
        slots[slotNumber].UpdateSlotUI(itemNumber);
        slotNumber += 1;
        //Debug.Log($"{slots[0].item.itemName}");
    }
}
