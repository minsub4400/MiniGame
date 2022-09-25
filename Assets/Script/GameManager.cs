using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Inventory inventory;

    // 채집 시, 트리거 엔터되면 채집물의 인덱스를 가져온다
    public InteractionUI interactionUI;

    
    // 채집 게이지를 찾을 변수
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

    // 해당 아이템을 인벤토리 리스트에 넣는다
    private void InputInInven()
    {
        inventory.AddItem(interactionUI.itemNumber);
        Debug.Log("아이템 습득 중..");
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
