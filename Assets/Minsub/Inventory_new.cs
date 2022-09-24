using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_new : MonoBehaviour
{
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotsParent;

    private Slot[] slots;
    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
    }

    void Update()
    {
        
    }

    public void AcqireItem(Item _item, int _count = 1)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                if (slots[i].item.itemName == _item.itemName)
                {
                    slots[i].SetSlotCount(_count);
                    return;
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }
}
