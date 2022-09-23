using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public GameObject Inventory;
    public GameObject GetteringUI;
    public GameObject LodingUI;

    private bool InvenKey = false;
    

   

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            InvenKey = !InvenKey;
            Inventory.SetActive(InvenKey);
        }
    }

    private void Awake()
    {
        Instance = this;
        GetteringUI.SetActive(false);


    }

    public void DeActivationGetteringUI()
    {
        GetteringUI.SetActive(false);
    }

    public void ActivationGetteringUI()
    {
        GetteringUI.SetActive(true);
    }
    public void LodingScreenUI()
    {
        LodingUI.SetActive(true);
    }




}
