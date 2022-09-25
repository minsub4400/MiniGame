using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIngredient : MonoBehaviour
{
    // ����Ȯ���� ������ ��´�.
    [Header("ä���� ����")]
    // ���� ������ ������ ����
    [SerializeField] private int RandomQuantity;
    [Header("�ּҰ�")]
    public int Min;
    [Header("�ִ밪")]
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
