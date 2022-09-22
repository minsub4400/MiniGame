using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public GameObject InteractionUi;
    public PlayerInput Key;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == null) return;
        if (Key.InteractionOn == false)
        { 
            if (other.CompareTag("Item"))
            {
                
                Debug.Log("À¸¾Æ¾Æ");
                InteractionUi.SetActive(true);

            }
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            InteractionUi.SetActive(false);
        }
    }
}
