using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public ItemData itemData;

    private void Start()
    {
        //StartCoroutine(Spawn());
    }

    private void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        Debug.Log($"������ : {gameObject.activeSelf}");
        if (gameObject.active == false)
        {
            Debug.Log("�ȳ��ϼ���");
            yield return new WaitForSeconds(10);
            gameObject.SetActive(true);
        }
        yield return null;
    }
}


