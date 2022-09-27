using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIngredient : MonoBehaviour
{
    public static RandomIngredient randomIngredient;
    private void Awake()
    {
        randomIngredient = this;
    }
    // ����Ȯ���� ������ ��´�.
    [Header("ä���� ����")]
    // ���� ������ ������ ����
    [SerializeField] private int RandomQuantity;
    [Header("�ּҰ�")]
    public int Min;
    [Header("�ִ밪")]
    public int Max;

    public ItemData itemData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            itemData.NumberOfAcquisitions = Random.Range(Min, Max);
        }
    }
}
