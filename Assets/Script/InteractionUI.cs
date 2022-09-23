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
            if (other.CompareTag("Item")) //아이템이면
            {
                InteractionUi.SetActive(true); //상호작용 오브젝트중에

                foreach (string name in EnergyTable.Keys) // 딕셔너리 스트링 , float값 저장
                {
                    if (other.name == name) //오브젝트의 이름과 딕셔너리의 이름이 같으면 float값 넣어줌
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
