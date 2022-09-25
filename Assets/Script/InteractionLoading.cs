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

    // 로딩이 완료되었을 경우 확인할 변수
    public bool isLoaingComplite;
    private void Awake()
    {
        isLoaingComplite = false;
        gameObject.SetActive(false);
    }

    void Update()
    {
        Loading(Energys.lt); //UI에 시간초 넣어줌
    }

    public void Loading(float maxTime)
    {
        elaspedTime += Time.deltaTime;
        LoadingSlider.value = Mathf.Lerp(0f, 1f, elaspedTime / maxTime);
        if (elaspedTime >= maxTime)
        {
            //< --이거 넣으면 채집물이 하나이상 안캐져서 임시로 주석처리함
            _animator.SetBool("Attack", false); // 인풋으로 빼기
            elaspedTime = 0f;
            Debug.Log($"밸류값 : {LoadingSlider.value}");
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
