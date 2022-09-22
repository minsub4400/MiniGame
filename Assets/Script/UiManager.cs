using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    

    private bool isPIP = false;

    private void Awake()
    {
        
    }

    void Update()
    {
        
    }

    private void PIP()
    {
        Debug.Log("아이템 습득 중..");
        //inventory.AddItem();
    }

    
}
