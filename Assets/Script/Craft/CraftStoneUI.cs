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
        for (int i = 0; i < Inventory_new.inventory_new.itemsIndex.Count; i++) // ����Ʈ�� ���� ��ŭ �ݺ��Ѵ�
        {   // 1. �ε������� ���縦 ã�´�.
            if (Inventory_new.inventory_new.itemsIndex[i] == 2)
            {
                text.text = $"�� : {Inventory_new.inventory_new.itemsCount[i]} / 3";
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
