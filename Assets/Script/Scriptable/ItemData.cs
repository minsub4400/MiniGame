using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [Header("ä���� �ε���")]
    public int ItemNumber;

    [Header("ä���� �̸�(ko)")]
    public string KorName;

    [Header("ä���� �̸�(en)")]
    public string EngName;

    [Header("ȹ�� ����")]
    public int NumberOfAcquisitions;
}