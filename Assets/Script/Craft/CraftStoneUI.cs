using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftStoneUI : MonoBehaviour
{

    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Inventory_new.inventory_new.itemsIndex.Count; i++) // 리스트의 갯수 만큼 반복한다
        {   // 1. 인덱스에서 목재를 찾는다.
            if (Inventory_new.inventory_new.itemsIndex[i] == 2)
            {
                text.text = $"돌 : {Inventory_new.inventory_new.itemsCount[i]} / 3";
                if (Inventory_new.inventory_new.itemsCount[i] >= 3)
                {
                    text.color = Color.yellow;
                }
                else
                {
                    text.color = Color.black;
                }
            }
        }
    }
    
}
