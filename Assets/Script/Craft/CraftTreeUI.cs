using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftTreeUI : MonoBehaviour
{
   
    // Start is called before the first frame update


    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Inventory_new.inventory_new.itemsIndex.Count; i++) // 리스트의 갯수 만큼 반복한다
        {   // 1. 인덱스에서 목재를 찾는다.
            if (Inventory_new.inventory_new.itemsIndex[i] == 1)
            {
                text.text = $"목재 : {Inventory_new.inventory_new.itemsCount[i]} / 5";
                if (Inventory_new.inventory_new.itemsCount[i] >= 5)
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
