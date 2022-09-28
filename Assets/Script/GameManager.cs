using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Inventory_new inventory_new;

    // ä�� ��, Ʈ���� ���͵Ǹ� ä������ �ε����� �����´�
    public InteractionUI interactionUI;

    // ä�� �������� ã�� ����
    public InteractionLoding interactionLoding;

    // �κ��丮�� ���Ë� ����� ���� ����
    private AudioSource inventoryGetItemSound;

    void Start()
    {
        inventory_new = FindObjectOfType<Inventory_new>();
        interactionLoding = FindObjectOfType<InteractionLoding>();
        interactionUI = FindObjectOfType<InteractionUI>();
        inventoryGetItemSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        IndexAndGaugeComparison();

        if (inventory_new.woodBoxCount == 3)
        {
            SceneManager.LoadScene(2);
        }
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
        try
        {
            inventory_new.AddItem(interactionUI.itemIndexData, interactionUI.itemRandNum, interactionUI.itemImageData);
        }
        catch
        {
            Debug.Log("1");
        }
        // �������� ��� �ö�, ����� ����
        inventoryGetItemSound.Play();
        PickUpItemText.instance.DataUpdate();
        //Debug.Log("������ ���� ��..");
    }
}
