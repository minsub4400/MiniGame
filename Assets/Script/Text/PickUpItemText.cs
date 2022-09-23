using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PickUpItemText : MonoBehaviour
{
    // 텍스트 변수
    private TextMeshProUGUI textMeshProUGUI;

    // 데이터를 가져올 변수
    private InteractionUI interactionUI;

    public string itemName;
    public int itemCount;

    void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        interactionUI = GameObject.Find("Player").transform.Find("direction").GetComponent<InteractionUI>();
    }

    private void Update()
    {
        DataUpdate();
    }

    void DataUpdate()
    {
        itemName = interactionUI.itemName;
        itemCount = interactionUI.randomData;
        textMeshProUGUI.text = $"{interactionUI.itemName} : {interactionUI.randomData}";
    }
}
