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
            if (other.CompareTag("Item")) //�������̸�
            {
                InteractionUi.SetActive(true); //��ȣ�ۿ� ������Ʈ�߿�

                foreach (string name in EnergyTable.Keys) // ��ųʸ� ��Ʈ�� , float�� ����
                {
                    if (other.name == name) //������Ʈ�� �̸��� ��ųʸ��� �̸��� ������ float�� �־���
                    {
                        Energy = other.gameObject;
                        lt = EnergyTable[name];
                        Debug.Log($"{lt}");
                    }
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            InteractionUi.SetActive(false);
        }
    }
}
