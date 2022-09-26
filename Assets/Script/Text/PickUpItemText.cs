using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PickUpItemText : MonoBehaviour
{
    public static PickUpItemText instance;

    // �ؽ�Ʈ ����
    private Text textMeshProUGUI;

    // �����͸� ������ ����
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

    // �� ĺ�� �� ȣ�� �Ѵ�.
    public void DataUpdate()
    {
        itemIndex = interactionUI.itemIndexData;
        itemRandNum = interactionUI.itemRandNum;
        itemName_ko = interactionUI.itemNameData_ko;
        textMeshProUGUI.text = $"+{itemRandNum} {itemName_ko} ȹ���߽��ϴ�.";
    }
}
