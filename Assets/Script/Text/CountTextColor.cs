using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountTextColor : MonoBehaviour
{
    // �ڽ��� �ؽ�Ʈ�� �����ͼ� 99���� �Ǻ��ϰ�
    // 99�� ��������� ���� �����Ѵ�
    public int maxNumber = 99;

    private TextMeshProUGUI textMeshPro;

    private Color textColor;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textColor = textMeshPro.color;

    }

    private void Update()
    {
        /*if (int.Parse(textMeshPro.text) == maxNumber)
        {
            textColor = new Color(255f, 224f, 0f);
        }*/
    }
}
