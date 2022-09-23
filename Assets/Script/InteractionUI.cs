using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public GameObject InteractionUi;
    public PlayerInput Key;

    // �������� �ε����� ������ ����
    public int itemNumber = -1;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == null) return;
        if (Key.InteractionOn == false)
        { 
            if (other.CompareTag("Diamond"))
            {  
                InteractionUi.SetActive(true);
            }

            if (other.CompareTag("Wood"))
            {
                InteractionUi.SetActive(true);
            }

            if (other.CompareTag("Rock"))
            {
                InteractionUi.SetActive(true);
            }

            if (other.CompareTag("Hard Wood"))
            {
                InteractionUi.SetActive(true);
            }
        }
    }

    public int randomData = 0;
    public string itemName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Untagged")
        {
            // �ش� ä������ �����͸� �����´�.
            ItemInfo itemData = other.GetComponent<ItemInfo>();
            // �ش� ä������ �ε����� �����´�.
            itemNumber = itemData.itemData.ItemNumber;

            // �ش� ä������ �����͸� �����´�.
            RandomIngredient randomIngredient = other.GetComponent<RandomIngredient>();
            randomData = randomIngredient.itemData.NumberOfAcquisitions;
            itemName = randomIngredient.itemData.EngName;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        itemNumber = -1;
        if (other.CompareTag("Diamond"))
        {
            InteractionUi.SetActive(false);
        }
    }
}
