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
    // �������� �ε����� ������ ����
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


            // �ش� ä������ �����͸� �����´�.
            itemNumber = other.GetComponent<RandomIngredient>().itemData.ItemNumber;
            // �ش� ä������ �ε����� �����´�. 
            
            // �ش� ä������ �����͸� �����´�.
            randomData = other.GetComponent<RandomIngredient>().itemData.NumberOfAcquisitions;
            itemName = other.GetComponent<RandomIngredient>().itemData.EngName;
            //Debug.Log(randomData);
            //Debug.Log(itemName);
            Energy = other.gameObject;
            foreach (string name in EnergyTable.Keys) // ��ųʸ� ��Ʈ�� , float�� ����
            {
                if (other.name == name) //������Ʈ�� �̸��� ��ųʸ��� �̸��� ������ float�� �־���
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




    //��ȣ�ۿ� ������Ʈ�߿�   
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
