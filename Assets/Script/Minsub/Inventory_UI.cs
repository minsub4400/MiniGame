using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public static Inventory_UI instance;
    Inventory_new inven;
    public Slot[] slots;
    public Transform slotHolder;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven = Inventory_new.inventory_new;
        inven.onChangeItem += RedrawSlotUI;
        inven.onSlotCountChange += SlotChange;
    }

    private void SlotChange(int val)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inven.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void AddSlot()
    {
        inven.SlotCnt++;
    }

    private void RedrawSlotUI()
    {

        /*for (int j = 0; j < inven.itemsIndex.Count; j++)
        {
            if (inven.itemsIndex[j] == -1)
            {
                //Debug.Log($"{j} 인덱스 : {inven.itemsIndex[j]}");
                slots[j].itemCount = 0;
                slots[j].itemIcon = inven.whiteImageSprite;
                slots[j].UpdateSlotImageUI(inven.whiteImageSprite);
                slots[j].UpdateSlotTextUI(0);
            }
        }*/

        for (int i = 0; i < inven.itemsIndex.Count; i++)
        {
            if (inven.itemsIndex[i] == -1)
            {
                //Debug.Log(inven.itemsIndex[i]);
                for (int j = 0; j < inven.itemsIndex.Count; j++)
                {
                    if (inven.itemsIndex[j] == -1)
                    {
                        slots[j].itemCount = 0;
                        slots[j].itemIcon = inven.whiteImageSprite;
                        slots[j].UpdateSlotImageUI(inven.whiteImageSprite);
                        slots[j].UpdateSlotTextUI(0);
                    }
                }
                return;
            }

            /*for (int j = 0; j < inven.itemsIndex.Count; j++)
            {
                if (inven.itemsIndex[j] == -1)
                {
                    slots[j].itemCount = 0;
                    slots[j].itemIcon = inven.whiteImageSprite;
                    slots[j].UpdateSlotImageUI(inven.whiteImageSprite);
                    slots[j].UpdateSlotTextUI(0);
                }
            }*/

            slots[i].itemIndex = inven.itemsIndex[i];
            slots[i].itemCount = inven.itemsCount[i];
            slots[i].itemIcon = inven.itemsImage[i];
            slots[i].UpdateSlotImageUI(inven.itemsImage[i]);
            slots[i].UpdateSlotTextUI(inven.itemsCount[i]);
        }
    }

    public void RedrawCountSlotUI(int index)
    {
        // 같은 아이템이 있는 인덱스를 찾아서 Count를 넣어준다.
        slots[index].itemCount = inven.itemsCount[index];
        slots[index].UpdateSlotTextUI(inven.itemsCount[index]);
    }
}
