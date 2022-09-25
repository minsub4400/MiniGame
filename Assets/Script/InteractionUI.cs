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
    // 아이템의 인덱스를 저장할 변수
    public int itemNumber = -1;
    private void Start()
    {
        EnergyTable.Add("Wood", ObjectTime[0]);
        EnergyTable.Add("HardWood", ObjectTime[1]);
        EnergyTable.Add("Rock", ObjectTime[2]);
        EnergyTable.Add("Diamond", ObjectTime[3]);
    }
    public int randomData = 0;
    public string itemName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond")
                || other.CompareTag("Wood")
                || other.CompareTag("Hard Wood")
                || other.CompareTag("Rock"))
        {


            // 해당 채집물의 데이터를 가져온다.
            itemNumber = other.GetComponent<RandomIngredient>().itemData.ItemNumber;
            // 해당 채집물의 인덱스를 가져온다. 
            
            // 해당 채집물의 데이터를 가져온다.
            randomData = other.GetComponent<RandomIngredient>().itemData.NumberOfAcquisitions;
            itemName = other.GetComponent<RandomIngredient>().itemData.EngName;
            //Debug.Log(randomData);
            //Debug.Log(itemName);
            Energy = other.gameObject;
            foreach (string name in EnergyTable.Keys) // 딕셔너리 스트링 , float값 저장
            {
                if (other.name == name) //오브젝트의 이름과 딕셔너리의 이름이 같으면 float값 넣어줌
                {

                    lt = EnergyTable[name];
                    //Debug.Log($"{lt}");
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Diamond")
               || other.CompareTag("Wood")
               || other.CompareTag("Hard Wood")
               || other.CompareTag("Rock"))
        {
            Debug.Log(itemNumber);
            InteractionUi.SetActive(true);
        }
    }




    //상호작용 오브젝트중에   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Diamond")
            || other.CompareTag("Wood")
            || other.CompareTag("Hard Wood")
            || other.CompareTag("Rock"))
        {
            itemNumber = -1;
            Energy = null;
            InputKey.InteractionOn = false;
            InteractionUi.SetActive(false);
        }
    }
}
