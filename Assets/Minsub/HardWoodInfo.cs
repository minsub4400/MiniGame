using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HardWood Data", menuName = "HardWood Data Object/Item Data", order = int.MaxValue)]
public class HardWoodInfo : MonoBehaviour
{
    [Header("Ã¤Áı¹° ÀÎµ¦½º")]
    public int ItemIndex;

    [Header("Ã¤Áı¹° ÀÌ¸§(ko)")]
    public string KorName;

    [Header("Ã¤Áı¹° ÀÌ¸§(en)")]
    public string EngName;

    [Header("È¹µæ °¹¼ö")]
    public int NumberOfAcquisitions;
    public int min = 1;
    public int max = 6;

    [Header("¾ÆÀÌÅÛ ÀÌ¹ÌÁö")]
    public Sprite spriteImage;

    private int randNum;
    private void Awake()
    {
        // ·£´ı È¹µæ °¹¼ö
        randNum = Random.Range(min, max);
        NumberOfAcquisitions = randNum;
    }
}