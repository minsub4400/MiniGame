using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LackOfMaterialButton : MonoBehaviour
{
    // Ȯ�� ��ư�� ������ ���� ���� ������Ʈ false

    [SerializeField]
    private GameObject gameObjectParent;
    public void GameObjectFalseCheck()
    {
        gameObjectParent.gameObject.SetActive(false);
    }
}
