using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Inventory_new inventory_new;

    // 채집 시, 트리거 엔터되면 채집물의 인덱스를 가져온다
    private InteractionUI interactionUI;

    // 채집 게이지를 찾을 변수
    private InteractionLoding interactionLoding;

    // 인벤토리에 들어올떄 재생할 사운드 변수
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

    // 해당 아이템을 인벤토리 리스트에 넣는다.
    private void InputInInven()
    {
        //Debug.Log(interactionUI.itemIndexData);
        //Debug.Log(interactionUI.itemRandNum);
        // 성공
        inventory_new.AddItem(interactionUI.itemIndexData, interactionUI.itemRandNum, interactionUI.itemImageData);
        // 아이템이 들어 올때, 재생될 사운드
        inventoryGetItemSound.Play();
        PickUpItemText.instance.DataUpdate();
        //Debug.Log("아이템 습득 중..");
    }
}
