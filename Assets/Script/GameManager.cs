using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Inventory inventory;

    // ä�� ��, Ʈ���� ���͵Ǹ� ä������ �ε����� �����´�
    public InteractionUI interactionUI;

    
    // ä�� �������� ã�� ����
    public InteractionLoading interactionLoding;
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        
    }
    void Update()
    {
         
        IndexAndGaugeComparison();
        
    }
    private void IndexAndGaugeComparison()
    {
        if (interactionLoding.isLoaingComplite && interactionUI.itemNumber != -1)
        {
            InputInInven();
            interactionLoding.isLoaingComplite = false;
        }
    }

    // �ش� �������� �κ��丮 ����Ʈ�� �ִ´�
    private void InputInInven()
    {
        inventory.AddItem(interactionUI.itemNumber);
        Debug.Log("������ ���� ��..");
        Debug.Log(interactionUI.itemNumber);
    }

    private void Spawn()
    {

    }

    private void OffRenderobject(GameObject Energy)
    {
        Energy.GetComponent<MeshCollider>().enabled = false;
        Energy.GetComponent<MeshRenderer>().enabled = false;
        Energy.GetComponent<BoxCollider>().enabled = false;

    }

    private void OnRenderobject(GameObject Energy)
    {
        Energy.GetComponent<MeshCollider>().enabled = true;
        Energy.GetComponent<MeshRenderer>().enabled = true;
        Energy.GetComponent<BoxCollider>().enabled = true;

    }


}
