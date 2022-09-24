using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionLoding : MonoBehaviour
{
    public PlayerInput IntertionUi;
    public Slider loding;
    private float elaspedTime;
    public InteractionUI Energy;
    //private float maxTime = 3f;
    public Animator _animator;
    private float SpawnTime = 5f;
    private float SpT;

    // �ε��� �Ϸ�Ǿ��� ��� Ȯ���� ����
    public bool isLoingComplite;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        isLoingComplite = false;
    }

    void Update()
    {
        Loding(Energy.lt);
        //Loding();
    }

    /*public void Loding()
    {
        elaspedTime += Time.deltaTime;
        loding.value = Mathf.Lerp(0f, 1f, elaspedTime / maxTime);
        if (elaspedTime >= maxTime)
        {
            elaspedTime = 0f;
            loding.value = 1f;
            gameObject.SetActive(false);
            IntertionUi.InteractionOn = false;
        }
        LodingComplite();
    }*/

    public void Loding(float maxTime)
    {
        SpT+= Time.deltaTime;
        elaspedTime += Time.deltaTime;
        loding.value = Mathf.Lerp(0f, 1f, elaspedTime / maxTime);
        _animator.SetBool("Attack", true);
        if (elaspedTime >= maxTime)
        {
           //< --�̰� ������ ä������ �ϳ��̻� ��ĳ���� �ӽ÷� �ּ�ó����
            _animator.SetBool("Attack", false);
            elaspedTime = 0f;
            
            Onoffgameobject(Energy.Energy);
            loding.value = 1f;
            gameObject.SetActive(false);
            IntertionUi.InteractionOn = false;
        }

        if (loding.value == 1f)
        {
            LodingComplite();
        }
    }

    // �ε��� 1�� �Ǹ� �Ϸ�Ǿ��ٰ� ���ӸŴ������� �˷���
    private void LodingComplite()
    {
        isLoingComplite = true;
    }
    void Onoffgameobject(GameObject Energy)
    {
        Energy.GetComponent<MeshCollider>().enabled = false;
        Energy.GetComponent<MeshRenderer>().enabled = false;
        Energy.GetComponent<BoxCollider>().enabled = false;
        Debug.Log($"{SpT}");
        if(SpT >= SpawnTime)
        {
            SpT = 0f;
            Energy.GetComponent<MeshCollider>().enabled = true;
            Energy.GetComponent<MeshRenderer>().enabled = true;
            Energy.GetComponent<BoxCollider>().enabled = true;
        }
    }
    
}
