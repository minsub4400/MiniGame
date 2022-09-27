using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Diamond Data", menuName = "Diamond Data Object/Item Data", order = int.MaxValue)]
public class DiamondInfo : MonoBehaviour
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

    private float elaspedTime;
    private float SpawnTime = 5f;
    private MeshCollider _meshCollider;
    private MeshRenderer _meshRenderer;
    private MeshRenderer[] _myChildrenMeshRenderer;
    private int randNum;


    private void Awake()
    {
        randNum = Random.Range(min, max);
        NumberOfAcquisitions = randNum;
        _meshCollider = GetComponent<MeshCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _myChildrenMeshRenderer = GetComponentsInChildren<MeshRenderer>();
    }
    private void Update()
    {
        if (!_meshCollider.enabled && !_meshRenderer.enabled)
        {
            elaspedTime += Time.deltaTime;
            if (elaspedTime >= SpawnTime)
            {
                elaspedTime = 0f;
                _meshCollider.enabled = true;
                _meshRenderer.enabled = true;

                for (int i = 0; i < _myChildrenMeshRenderer.Length; i++)
                {
                    _myChildrenMeshRenderer[i].enabled = true;
                }
            }

        }
    }
}