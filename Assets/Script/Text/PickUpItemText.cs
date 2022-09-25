using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PickUpItemText : MonoBehaviour
{
    // �ؽ�Ʈ ����
    private TextMeshProUGUI textMeshProUGUI;

    // �����͸� ������ ����
    private InteractionUI interactionUI;

    public int itemIndex;
    public int itemRandNum;

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
        itemIndex = interactionUI.itemIndexData;
        itemRandNum = interactionUI.itemRandNum;
        textMeshProUGUI.text = $"{itemIndex} : {itemRandNum}";
    }
}
