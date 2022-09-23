using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Inventory inventory;

    // 채집 시, 트리거 엔터되면 채집물의 인덱스를 가져온다
    private InteractionUI interactionUI;

    // 채집 게이지를 찾을 변수
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

    // 해당 아이템을 인벤토리 리스트에 넣는다
    private void InputInInven()
    {
        inventory.AddItem(interactionUI.itemNumber);
        Debug.Log("아이템 습득 중..");
        Debug.Log(interactionUI.itemNumber);
    }
}
