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

    // 로딩이 완료되었을 경우 확인할 변수
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
           //< --이거 넣으면 채집물이 하나이상 안캐져서 임시로 주석처리함
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

    // 로딩이 1이 되면 완료되었다고 게임매니저에게 알려줌
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
