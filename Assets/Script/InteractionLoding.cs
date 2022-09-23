using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionLoding : MonoBehaviour
{
    public PlayerInput IntertionUi;
    public Slider loding;
    private float maxTime = 3f;
    private float elaspedTime;

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
        Loding();
    }

    public void Loding()
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
    }

    // 로딩이 1이 되면 완료되었다고 게임매니저에게 알려줌
    private void LodingComplite()
    {
        if (loding.value == 1f)
        {
            isLoingComplite = true;
        }
    }
}
