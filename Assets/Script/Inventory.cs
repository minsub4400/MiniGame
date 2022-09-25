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

    // ������ ȹ���ϸ� ���� ����Ʈ
    //public List<Item> items = new List<Item>();

    // ������ ������ ���� ����Ʈ
    //public List<Item> itemCounts = new List<Item>();

    // ������ Max ����
    [Header("������ Max ����")]
    public int itemMaxCount = 99;

    // ������ �ߺ� ��, �ε����� ����ϱ� ���� ����
    private int index_dic = 0;

    // ������ �ε����� ������ ����
    private int slotNumber = 0;

    //public Dictionary<string, List<int>> item_dic = new Dictionary<string, List<int>>();
    public Dictionary<string, int> item_dic = new Dictionary<string, int>();

    // ������ ���� ������Ʈ�� ���� ����
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
                Debug.Log($"�ι�° slotNumber : {slotNumber}");
                //Debug.Log(item_dic[ItemDB.instance.itemDB[itemNumber].itemName][i]);
                //item_dic[ItemDB.instance.itemDB[itemNumber].itemName][index_dic] += itemCount.itemCount;
                //item_dic[ItemDatabase.itemDatabase.itemDB[itemNumber].itemName] += itemCount.itemCount;
                DrawItemCountUI(itemNumber);
                return;
            }*//*
            //else if (int.Parse(TextCount[index_dic].text) == itemMaxCount && item_dic.Keys.ElementAt(0) == ItemDB.instance.itemDB[itemNumber].itemName)
            else if (int.Parse(TextCount[index_dic].text) == itemMaxCount && item_dic.Keys.ElementAt(slotNumber) == ItemDatabase.itemDatabase.itemDB[itemNumber].itemName)
            {
                Debug.Log($"����° slotNumber : {slotNumber}");
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

    // ������ �ߺ��� �ȵǾ��� ��� �Լ�
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

    // �������� �ߺ��� �Ǿ��� ��� �Լ�
    public void DrawItemCountUI(int itemNumber)
    {
        //Debug.Log(TextCount[0].text);
        //if (item_dic[ItemDB.instance.itemDB[itemNumber].itemName][index_dic] != itemMaxCount)
        //Debug.Log(item_dic[ItemDB.instance.itemDB[itemNumber].itemName][i]);
        // ��ųʸ����� Key�� �ε��� ã��
        //index_dic = Array.IndexOf(item_dic.Keys.ToArray(), ItemDatabase.itemDatabase.itemDB[itemNumber].itemName);
        Debug.Log(index_dic);

        //slots[index_dic].UpdateSlotTextCountUI(itemNumber, index_dic);

    }
}
