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
        Debug.Log($"에너지 : {gameObject.activeSelf}");
        if (gameObject.active == false)
        {
            Debug.Log("안녕하세요");
            yield return new WaitForSeconds(10);
            gameObject.SetActive(true);
        }
        yield return null;
    }
}


