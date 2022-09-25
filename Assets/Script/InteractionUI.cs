using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public GameObject InteractionUi;
    public PlayerInput InputKey;
    public GameObject Energy;
    public Dictionary<string, float> EnergyTable = new Dictionary<string, float>();
    public float[] ObjectTime = new float[4];
    public float lt;

    private void Awake()
    {
        Energy = GetComponent<GameObject>();
    }
    // 아이템의 정보를 가져왔는지 확인할 수 있는 변수
    public bool itemInfoCheck = false;
    private void Start()
    {
        EnergyTable.Add("Wood", ObjectTime[0]);
        EnergyTable.Add("HardWood", ObjectTime[1]);
        EnergyTable.Add("Rock", ObjectTime[2]);
        EnergyTable.Add("Diamond", ObjectTime[3]);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == null) return;
        if (InputKey.InteractionOn == false)
        {
            if (other.CompareTag("Diamond")
                || other.CompareTag("Wood")
                || other.CompareTag("Hard Wood")
                || other.CompareTag("Rock")) //아이템이면
            {
                InteractionUi.SetActive(true); //상호작용 오브젝트중에

                foreach (string name in EnergyTable.Keys) // 딕셔너리 스트링 , float값 저장
                {
                    if (other.name == name) //오브젝트의 이름과 딕셔너리의 이름이 같으면 float값 넣어줌
                    {
                        Energy = other.gameObject;
                        lt = EnergyTable[name];
                        //Debug.Log($"{lt}");
                    }
                }
            }
        }
    }

    public int itemIndexData;
    public int itemRandNum;
    public Sprite itemImageData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Diamond"))
        {
            DiamondInfo itemData = other.GetComponent<DiamondInfo>();
            itemIndexData = itemData.ItemIndex;
            itemRandNum = itemData.NumberOfAcquisitions;
            itemImageData = itemData.spriteImage;
            itemInfoCheck = true;
        }
        if (other.tag == ("Rock"))
        {
            RockInfo itemData = other.GetComponent<RockInfo>();
            itemIndexData = itemData.ItemIndex;
            itemRandNum = itemData.NumberOfAcquisitions;
            itemImageData = itemData.spriteImage;
            itemInfoCheck = true;
        }
        if (other.tag == ("Wood"))
        {
            WoodInfo itemData = other.GetComponent<WoodInfo>();
            itemIndexData = itemData.ItemIndex;
            itemRandNum = itemData.NumberOfAcquisitions;
            itemImageData = itemData.spriteImage;
            itemInfoCheck = true;
        }
        if (other.tag == ("Hard Wood"))
        {
            HardWoodInfo itemData = other.GetComponent<HardWoodInfo> ();
            itemIndexData = itemData.ItemIndex;
            itemRandNum = itemData.NumberOfAcquisitions;
            itemImageData = itemData.spriteImage;
            itemInfoCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        itemInfoCheck = false;
        if (other.CompareTag("Diamond")
            || other.CompareTag("Wood")
            || other.CompareTag("Hard Wood")
            || other.CompareTag("Rock"))
        {
            InteractionUi.SetActive(false);
        }
    }
}
