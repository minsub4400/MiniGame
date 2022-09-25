using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class Inventory : MonoBehaviour
{
    //public static Inventory inventory;

    // 아이템 획득하면 담을 리스트
    //public List<Item> items = new List<Item>();

    // 아이템 갯수를 담을 리스트
    //public List<Item> itemCounts = new List<Item>();

    // 아이템 Max 갯수
    [Header("아이템 Max 제한")]
    public int itemMaxCount = 99;

    // 아이템 중복 시, 인덱스를 기억하기 위한 변수
    private int index_dic = 0;

    // 슬롯의 인덱스를 지정할 변수
    private int slotNumber = 0;

    //public Dictionary<string, List<int>> item_dic = new Dictionary<string, List<int>>();
    public Dictionary<string, int> item_dic = new Dictionary<string, int>();

    // 아이템 갯수 컴포넌트를 담을 변수
    private PickUpItemText itemCount;
    public Slot[] slots;
    public Text[] TextCount;
    public GameObject slotsObj;
    public GameObject slotsTextObj;

    private void Awake()
    {
        itemCount = GameObject.Find("Canvas").transform.Find("PickUpItemText").GetComponent<PickUpItemText>();
        slots = slotsObj.GetComponentsInChildren<Slot>();
        TextCount = slotsTextObj.GetComponentsInChildren<Text>();
    }

    public void AddItem(int itemNumber)
    {
        /*foreach (KeyValuePair<string, int> items in item_dic)
        {
            //if (int.Parse(TextCount[index_dic].text) < itemMaxCount && item_dic.Keys.ElementAt(0) == ItemDB.instance.itemDB[itemNumber].itemName)
            *//*if (int.Parse(TextCount[slotNumber].text) < itemMaxCount && item_dic.Keys.ElementAt(index_dic) == ItemDatabase.itemDatabase.itemDB[itemNumber].itemName)
            {
                Debug.Log($"두번째 slotNumber : {slotNumber}");
                //Debug.Log(item_dic[ItemDB.instance.itemDB[itemNumber].itemName][i]);
                //item_dic[ItemDB.instance.itemDB[itemNumber].itemName][index_dic] += itemCount.itemCount;
                //item_dic[ItemDatabase.itemDatabase.itemDB[itemNumber].itemName] += itemCount.itemCount;
                DrawItemCountUI(itemNumber);
                return;
            }*//*
            //else if (int.Parse(TextCount[index_dic].text) == itemMaxCount && item_dic.Keys.ElementAt(0) == ItemDB.instance.itemDB[itemNumber].itemName)
            else if (int.Parse(TextCount[index_dic].text) == itemMaxCount && item_dic.Keys.ElementAt(slotNumber) == ItemDatabase.itemDatabase.itemDB[itemNumber].itemName)
            {
                Debug.Log($"세번째 slotNumber : {slotNumber}");
                //var list = new List<int> { itemCount.itemCount };
                //item_dic.Add(ItemDB.instance.itemDB[itemNumber].itemName, list);
                //item_dic[ItemDatabase.itemDatabase.itemDB[itemNumber].itemName] = itemCount.itemCount;
                //item_dic[ItemDB.instance.itemDB[itemNumber].itemName] = itemCount.itemCount;
                DrawItemUI(itemNumber);
                return;
            }
        }*/

        //var list = new List<int> { itemCount.itemCount };
        //item_dic.Add(ItemDatabase.itemDatabase.itemDB[itemNumber].itemName, itemCount.itemCount);
        Debug.Log($"key : {item_dic.Keys.ElementAt(0)}");
        Debug.Log($"value : {item_dic.Values.ElementAt(0)}");
        //Debug.Log($"value : {item_dic[ItemDB.instance.itemDB[itemNumber].itemName][slotNumber]}");
        Debug.Log("3");
        //DrawItemUI(itemNumber);
    }

    // 아이템 중복이 안되었을 경우 함수
    public void DrawItemUI(int itemNumber)
    {
        slotNumber += 1;
        //Debug.Log(item_dic[ItemDatabase.itemDatabase.itemDB[itemNumber].itemName]);
        if (int.Parse(TextCount[slotNumber].text) != itemMaxCount)
        {
            Debug.Log(slotNumber);
            //slots[slotNumber].item = ItemDatabase.itemDatabase.itemDB[itemNumber];
            //slots[slotNumber].item = items[slotNumber];
            //slots[slotNumber].UpdateSlotUI(itemNumber, slotNumber);
            //slotNumber += 1;
        }
    }

    // 아이템이 중복이 되었을 경우 함수
    public void DrawItemCountUI(int itemNumber)
    {
        //Debug.Log(TextCount[0].text);
        //if (item_dic[ItemDB.instance.itemDB[itemNumber].itemName][index_dic] != itemMaxCount)
        //Debug.Log(item_dic[ItemDB.instance.itemDB[itemNumber].itemName][i]);
        // 딕셔너리에서 Key로 인덱스 찾기
        //index_dic = Array.IndexOf(item_dic.Keys.ToArray(), ItemDatabase.itemDatabase.itemDB[itemNumber].itemName);
        Debug.Log(index_dic);

        //slots[index_dic].UpdateSlotTextCountUI(itemNumber, index_dic);

    }
}
