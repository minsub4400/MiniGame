using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIngredient2 : MonoBehaviour
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
