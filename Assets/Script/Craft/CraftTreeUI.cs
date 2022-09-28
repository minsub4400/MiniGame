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
        for (int i = 0; i < Inventory_new.inventory_new.itemsIndex.Count; i++) // ����Ʈ�� ���� ��ŭ �ݺ��Ѵ�
        {   // 1. �ε������� ���縦 ã�´�.
            if (Inventory_new.inventory_new.itemsIndex[i] == 1)
            {
                text.text = $"���� : {Inventory_new.inventory_new.itemsCount[i]} / 5";
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
