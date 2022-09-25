using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HardWood Data", menuName = "HardWood Data Object/Item Data", order = int.MaxValue)]
public class HardWoodInfo : MonoBehaviour
{
    [Header("ä���� �ε���")]
    public int ItemIndex;

    [Header("ä���� �̸�(ko)")]
    public string KorName;

    [Header("ä���� �̸�(en)")]
    public string EngName;

    [Header("ȹ�� ����")]
    public int NumberOfAcquisitions;
    public int min = 1;
    public int max = 6;

    [Header("������ �̹���")]
    public Sprite spriteImage;

    private int randNum;
    private void Awake()
    {
        // ���� ȹ�� ����
        randNum = Random.Range(min, max);
        NumberOfAcquisitions = randNum;
    }
}