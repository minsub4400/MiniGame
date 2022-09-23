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
