using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionLoading : MonoBehaviour
{
    public PlayerInput IntertionUi;
    public Slider LoadingSlider;
    private float elaspedTime;
    public InteractionUI Energys;


    private float timeview;
    //private float maxTime = 3f;
    public Animator _animator;

    // �ε��� �Ϸ�Ǿ��� ��� Ȯ���� ����
    public bool isLoaingComplite;
    private void Awake()
    {
        isLoaingComplite = false;
        gameObject.SetActive(false);
    }

    void Update()
    {
        Loading(Energys.lt); //UI�� �ð��� �־���
    }

    public void Loading(float maxTime)
    {
        elaspedTime += Time.deltaTime;
        LoadingSlider.value = Mathf.Lerp(0f, 1f, elaspedTime / maxTime);
        if (elaspedTime >= maxTime)
        {
            //< --�̰� ������ ä������ �ϳ��̻� ��ĳ���� �ӽ÷� �ּ�ó����
            _animator.SetBool("Attack", false); // ��ǲ���� ����
            elaspedTime = 0f;
            Debug.Log($"����� : {LoadingSlider.value}");
            Energyoff(Energys.Energy);
            Energys.Energy = null;
            isLoaingComplite = true;
            gameObject.SetActive(false);
            IntertionUi.InteractionOn = false;
        }



    }
    void Energyoff(GameObject Engery)
    {
        if (Engery.GetComponent<BoxCollider>().enabled == true && Engery.GetComponent<MeshCollider>().enabled == true)
        {
            Engery.GetComponent<MeshCollider>().enabled = false;
            Engery.GetComponent<BoxCollider>().enabled = false;

        }
        
        if (Engery.GetComponent<CapsuleCollider>().enabled == true)
        {
            Engery.GetComponent<CapsuleCollider>().enabled = false;
        }
            Engery.GetComponent<MeshRenderer>().enabled = false;

    }
}
