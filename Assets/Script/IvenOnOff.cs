using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인벤토리 버튼이 눌리면 켜진다.
// 한번더 누르면 꺼진다.
public class IvenOnOff : MonoBehaviour
{
    // 인벤토리 활성 유무
    private bool isIven = false;

    private GameObject inventory;

    void Start()
    {
        inventory = GameObject.Find("Canvas").transform.Find("Inventory").gameObject;
        inventory.SetActive(false);
    }

    public void IvenOn()
    {
        isIven = !isIven;

        if (isIven)
        {
            inventory.gameObject.SetActive(true);
        }
        else
        {
            inventory.gameObject.SetActive(false);
        }
    }
}
