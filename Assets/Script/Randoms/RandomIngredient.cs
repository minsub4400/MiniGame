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
    // 랜덤확률로 갯수를 얻는다.
    [Header("채집물 갯수")]
    // 랜덤 갯수를 저장할 변수
    [SerializeField] private int RandomQuantity;
    [Header("최소값")]
    public int Min;
    [Header("최대값")]
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
