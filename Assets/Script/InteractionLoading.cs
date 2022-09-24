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

    // 로딩이 완료되었을 경우 확인할 변수
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
        Loading(Energys.lt); //UI에 시간초 넣어줌
    }



    public void Loading(float maxTime)
    {
        elaspedTime += Time.deltaTime;
        LoadingSlider.value = Mathf.Lerp(0f, 1f, elaspedTime / maxTime);
        _animator.SetBool("Attack", true);

        if (elaspedTime >= maxTime)
        {
            //< --이거 넣으면 채집물이 하나이상 안캐져서 임시로 주석처리함
            _animator.SetBool("Attack", false); // 인푸으로 빼기
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

    // 로딩이 1이 되면 완료되었다고 게임매니저에게 알려줌
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
