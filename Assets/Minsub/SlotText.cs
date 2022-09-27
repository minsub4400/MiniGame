using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotText : MonoBehaviour
{
    private Text text;
    private Color color;
    private int maxItemNumber = 99;

    private void Awake()
    {
        text = GetComponent<Text>();
        color = text.color;
    }

    public void SetText(int _text)
    {
        text.text = _text.ToString();
    }

    private void Update()
    {
        if (int.Parse(text.text) == maxItemNumber)
        {
            ChangeSetColor();
        }
    }

    // 99개가 되면 219, 135, 0으로 변경
    private void ChangeSetColor()
    {
        color = new Color(207 / 255f, 127 / 255f, 20 / 255f, 255 / 255f);
        //new Color(255 / 255f, 10 / 255f, 10 / 255f, 255 / 255f);
        text.color = color;
    }
}
