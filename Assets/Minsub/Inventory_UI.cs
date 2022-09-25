using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    Inventory_new inven;
    public Slot[] slots;
    public Transform slotHolder;

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
        /*for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }*/
        for (int i = 0; i < inven.itemsIndex.Count; i++)
        {
            slots[i].itemIndex = inven.itemsIndex[i];
            slots[i].itemCount = inven.itemsCount[i];
            slots[i].itemIcon = inven.itemsImage[i];
            slots[i].UpdateSlotImageUI(inven.itemsImage[i]);
            slots[i].UpdateSlotTextUI(inven.itemsCount[i]);
        }
    }
}
