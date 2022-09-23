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

    // �ε��� 1�� �Ǹ� �Ϸ�Ǿ��ٰ� ���ӸŴ������� �˷���
    private void LodingComplite()
    {
        if (loding.value == 1f)
        {
            isLoingComplite = true;
        }
    }
}
