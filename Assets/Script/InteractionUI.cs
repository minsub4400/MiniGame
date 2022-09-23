using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public GameObject InteractionUi;
    public PlayerInput Key;

    // 아이템의 인덱스를 저장할 변수
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
            // 해당 채집물의 데이터를 가져온다.
            ItemInfo itemData = other.GetComponent<ItemInfo>();
            // 해당 채집물의 인덱스를 가져온다.
            itemNumber = itemData.itemData.ItemNumber;

            // 해당 채집물의 데이터를 가져온다.
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
