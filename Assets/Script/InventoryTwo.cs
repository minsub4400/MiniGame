using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTwo : MonoBehaviour
{
    #region Singleton
    public static InventoryTwo instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    #endregion
    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;
    private int slotCount;
    public int SlotCount
    {
        get => slotCount;
        set
        {
            slotCount = value;
            onSlotCountChange.Invoke(slotCount);
        }
    }

    private void Start()
    {
        slotCount = 20;
    }
}
