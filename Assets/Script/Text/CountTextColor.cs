using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountTextColor : MonoBehaviour
{
    // 자신의 텍스트를 가져와서 99인지 판별하고
    // 99면 노란색으로 색을 변경한다
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
