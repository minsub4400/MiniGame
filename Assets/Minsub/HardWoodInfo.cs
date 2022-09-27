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

    private float elaspedTime;
    private float SpawnTime = 5f;
    private MeshCollider _meshCollider;
    private MeshRenderer _meshRenderer;
    private int randNum;


    private void Awake()
    {
        randNum = Random.Range(min, max);
        NumberOfAcquisitions = randNum;
        _meshCollider = GetComponent<MeshCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
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


            }

        }
    }
}