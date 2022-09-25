using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIngredient : MonoBehaviour
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
    private MeshCollider _meshCollider;
    private MeshRenderer _meshRenderer;
    private BoxCollider _boxCollider;
    //private CapsuleCollider _capsuleCollider;
    //    _capsuleCollider = GetComponent<CapsuleCollider>();

    private void Awake()
    {
        _meshCollider = GetComponent<MeshCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();


    }
    private void Update()
    {
        if (!_meshCollider.enabled && !_meshRenderer.enabled && !_boxCollider.enabled)
        {
            elaspedTime += Time.deltaTime;
            if(elaspedTime >= SpawnTime)
            {
                elaspedTime = 0f;
                _meshCollider.enabled = true;
                 _meshRenderer.enabled = true;
                _boxCollider.enabled = true;
                

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
