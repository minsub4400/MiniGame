using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Inventory inventory;

    // ä�� ��, Ʈ���� ���͵Ǹ� ä������ �ε����� �����´�
    private InteractionUI interactionUI;

    // ä�� �������� ã�� ����
    private InteractionLoding interactionLoding;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
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
        inventory.AddItem(interactionUI.itemNumber);
        Debug.Log("������ ���� ��..");
        Debug.Log(interactionUI.itemNumber);
    }
}
