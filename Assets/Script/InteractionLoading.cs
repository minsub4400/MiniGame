using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionLoading : MonoBehaviour
{
    public PlayerInput IntertionUi;
    public Slider LoadingSlider;
    private float elaspedTime;
    private float elaspedTime2;
    public InteractionUI Energys;
    private bool noObject = false;
    private float SpawnTime = 5;

    //private float maxTime = 3f;
    public Animator _animator;

    // �ε��� �Ϸ�Ǿ��� ��� Ȯ���� ����
    public bool isLoaingComplite;

    private void Awake()
    {
        isLoaingComplite = false;
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        

        if (noObject)
        {
            elaspedTime2 += Time.deltaTime;
            if(SpawnTime >= elaspedTime2)
            {
            OnRenderobject(Energys.Energy);
                noObject = false;
            }

        }
        Loading(Energys.lt); //UI�� �ð��� �־���
    }



    public void Loading(float maxTime)
    {
        elaspedTime += Time.deltaTime;
        LoadingSlider.value = Mathf.Lerp(0f, 1f, elaspedTime / maxTime);
        _animator.SetBool("Attack", true);

        if (elaspedTime >= maxTime)
        {
            //< --�̰� ������ ä������ �ϳ��̻� ��ĳ���� �ӽ÷� �ּ�ó����
            _animator.SetBool("Attack", false); // ��Ǫ���� ����
            elaspedTime = 0f;
            LoadingSlider.value = 1f;
            OffRenderobject(Energys.Energy);
            gameObject.SetActive(false);
            IntertionUi.InteractionOn = false;
        }
        if (LoadingSlider.value == 1f)
        {
            LodingComplite();
        }
    }

    // �ε��� 1�� �Ǹ� �Ϸ�Ǿ��ٰ� ���ӸŴ������� �˷���
    private void LodingComplite()
    {
        isLoaingComplite = true;
    }

    private void OffRenderobject(GameObject Energy)
    {
        Energy.GetComponent<MeshCollider>().enabled = false;
        Energy.GetComponent<MeshRenderer>().enabled = false;
        Energy.GetComponent<BoxCollider>().enabled = false;
        noObject = true;
    }

    private void OnRenderobject(GameObject Energy)
    {
        Energy.GetComponent<MeshCollider>().enabled = true;
        Energy.GetComponent<MeshRenderer>().enabled = true;
        Energy.GetComponent<BoxCollider>().enabled = true;

    }
}
