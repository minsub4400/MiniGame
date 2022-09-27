using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PickUpItemText : MonoBehaviour
{
    public static PickUpItemText instance;

    // 텍스트 변수
    private Text textMeshProUGUI;

    // 데이터를 가져올 변수
    private InteractionUI interactionUI;

    public int itemIndex;
    public int itemRandNum;
    public string itemName_ko;

    void Awake()
    {
        instance = this;
        textMeshProUGUI = GetComponent<Text>();
        interactionUI = GameObject.Find("Player").transform.Find("direction").GetComponent<InteractionUI>();
    }

    // 다 캤을 떄 호출 한다.
    public void DataUpdate()
    {
        itemIndex = interactionUI.itemIndexData;
        itemRandNum = interactionUI.itemRandNum;
        itemName_ko = interactionUI.itemNameData_ko;
        textMeshProUGUI.text = $"+{itemRandNum} {itemName_ko} 획득했습니다.";
    }
}
