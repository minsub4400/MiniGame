using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    public static PlayerHUD Instance;
    public GameObject GetteringUI;
    public GameObject LodingUI;
    public GameObject InventoryUi;
    public GameObject PauseUi;

    private bool inventoryOn = false;
    private bool PauseOn = false;

    private void Awake()
    {
        Instance = this;
        GetteringUI.SetActive(false);
        PauseUi.SetActive(false);

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
    public void InventoryScreenUi()
    {
        inventoryOn = !inventoryOn;
        InventoryUi.SetActive(inventoryOn); 
    }
    public void pauseUi()
    {
        PauseOn = !PauseOn;
       PauseUi.SetActive(PauseOn);
        if(PauseOn)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
        
    }


}
