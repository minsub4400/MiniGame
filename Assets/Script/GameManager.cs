using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Inventory_new inventory_new;

    // ä�� ��, Ʈ���� ���͵Ǹ� ä������ �ε����� �����´�
    private InteractionUI interactionUI;

    // ä�� �������� ã�� ����
    private InteractionLoding interactionLoding;

    void Start()
    {
        inventory_new = FindObjectOfType<Inventory_new>();
        interactionLoding = FindObjectOfType<InteractionLoding>();
        interactionUI = FindObjectOfType<InteractionUI>();
    }

    void Update()
    {
        IndexAndGaugeComparison();
    }

    private void IndexAndGaugeComparison()
    {
        if (interactionLoding.isLoingComplite && interactionUI.itemInfoCheck)
        {
            InputInInven();
            interactionLoding.isLoingComplite = false;
            interactionUI.itemInfoCheck = false;
        }
    }

    // �ش� �������� �κ��丮 ����Ʈ�� �ִ´�.
    private void InputInInven()
    {
        //Debug.Log(interactionUI.itemIndexData);
        //Debug.Log(interactionUI.itemRandNum);
        // ����
        inventory_new.AddItem(interactionUI.itemIndexData, interactionUI.itemRandNum, interactionUI.itemImageData);
        Debug.Log("������ ���� ��..");
        
    }
}
