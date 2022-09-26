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
        
    }

    

    public void Loding(float maxTime)
    {
        elaspedTime += Time.deltaTime;
        loding.value = Mathf.Lerp(0f, 1f, elaspedTime / maxTime);
        _animator.SetBool("Attack", true);
        if (elaspedTime >= maxTime)
        {
            //Energy.gameObject.SetActive(false); <-- �̰� ������ ä������ �ϳ��̻� ��ĳ���� �ӽ÷� �ּ�ó����
            _animator.SetBool("Attack", false);
            elaspedTime = 0f;
            loding.value = 1f;
            gameObject.SetActive(false);
            invisible(Energy.Energy);
            Energy.Energy = null;
            IntertionUi.InteractionOn = false;
        }

        if (loding.value == 1f)
        {
            LodingComplite();
        }
    }

    private void LodingComplite()
    {
        isLoingComplite = true;
    }
    private void invisible(GameObject Energy)
    {
        Energy.GetComponent<MeshRenderer>().enabled = false;
        Energy.GetComponent<MeshCollider>().enabled = false;
    }
}
