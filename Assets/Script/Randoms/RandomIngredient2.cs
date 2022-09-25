using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIngredient2 : MonoBehaviour
{
    // 랜덤확률로 갯수를 얻는다.
    [Header("채집물 갯수")]
    // 랜덤 갯수를 저장할 변수
    [SerializeField] private int RandomQuantity;
    [Header("최소값")]
    public int Min;
    [Header("최대값")]
    public int Max;
    public ItemData itemData;

    private float elaspedTime;
    private float SpawnTime = 5f;
    private MeshRenderer _meshRenderer;
    private CapsuleCollider _capsuleCollider;

    private void Awake()
    {
        
        _meshRenderer = GetComponent<MeshRenderer>();
        _capsuleCollider = GetComponent<CapsuleCollider>();


    }
    private void Update()
    {
        if (!_capsuleCollider.enabled && !_meshRenderer.enabled)
        {
            elaspedTime += Time.deltaTime;
            if (elaspedTime >= SpawnTime)
            {
                elaspedTime = 0f;
                _capsuleCollider.enabled = true;
                _meshRenderer.enabled = true;           
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            itemData.NumberOfAcquisitions = Random.Range(Min, Max);
        }
    }

}
