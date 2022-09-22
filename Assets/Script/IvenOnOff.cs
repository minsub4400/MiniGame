using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �κ��丮 ��ư�� ������ ������.
// �ѹ��� ������ ������.
public class IvenOnOff : MonoBehaviour
{
    // �κ��丮 Ȱ�� ����
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
