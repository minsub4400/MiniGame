using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [Header("채집물 인덱스")]
    public int ItemNumber;

    [Header("채집물 이름(ko)")]
    public string KorName;

    [Header("채집물 이름(en)")]
    public string EngName;

    [Header("획득 갯수")]
    public int NumberOfAcquisitions;
}