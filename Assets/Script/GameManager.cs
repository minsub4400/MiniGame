using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Inventory inventory;

    private bool isPIP = true;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if (isPIP && Input.GetKeyDown(KeyCode.D))
        {
            PIP();
            isPIP = false;
        }
    }

    private void PIP()
    {
        Debug.Log("아이템 습득 중..");
        inventory.AddItem();
    }
}
