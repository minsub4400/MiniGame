using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LackOfMaterialButton : MonoBehaviour
{
    // 확인 버튼이 눌리면 상위 게임 오브젝트 false

    [SerializeField]
    private GameObject gameObjectParent;
    public void GameObjectFalseCheck()
    {
        gameObjectParent.gameObject.SetActive(false);
    }
}
