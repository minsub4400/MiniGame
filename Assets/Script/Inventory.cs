using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // 아이템 획득하면 담을 리스트
    public List<Item> items = new List<Item>();
    private bool isPIP = false;
    public Slot[] slots;

    public void AddItem()
    {
        for (int i = 0; i < ItemDB.instance.itemDB.Count; i++)
        {
            //Debug.Log(ItemDB.instance.itemDB[i].itemName);
            items.Add(ItemDB.instance.itemDB[i]);
            //Debug.Log($"{i} : {items[i].itemName}");
        }
        DrawItemUI();
    }

    public void DrawItemUI()
    {
        for (int i = 0; i < items.Count; i++)
        {
            //Debug.Log("여기 까지 로그");
            //transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
            //transform.GetChild(i).gameObject.GetComponent<Image>().sprite = items[i].itemImage;
            slots[i].item = items[i];
            slots[i].UpdateSlotUI(i);
        }
        //Debug.Log($"{slots[0].item.itemName}");
    }
    public void OpenInvetory()
    {
        Debug.Log("인벤토리 켜져라");
        isPIP = !isPIP;
        gameObject.SetActive(isPIP);
    }
}
