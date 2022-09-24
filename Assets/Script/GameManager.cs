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
        if (interactionLoding.isLoingComplite && interactionUI.itemNumber != -1)
        {
            InputInInven();
            interactionLoding.isLoingComplite = false;
        }
    }

    // �ش� �������� �κ��丮 ����Ʈ�� �ִ´�
    private void InputInInven()
    {
        inventory_new.AcqireItem(interactionUI.itemName, interactionUI.randomData);
        //inventory.AddItem(interactionUI.itemNumber);
        Debug.Log("������ ���� ��..");
        Debug.Log($"������ �ε��� : {interactionUI.itemNumber}");
    }
}
