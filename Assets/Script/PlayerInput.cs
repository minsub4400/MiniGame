using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerCamera _playerCamera;
    public float MoveX;
    public float MoveZ;
    public bool InteractionOn = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        UpdateMove();
        Interaction();
        Intventroy();


    }

    //private void UpdateRotate()
    //{
    //    float mouseX = Input.GetAxis("Mouse X");
    //    float mouseY = Input.GetAxis("Mouse Y");
    //    _playerCamera.UpdateRotate(mouseX, mouseY);
    //}

    private void UpdateMove()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveZ = Input.GetAxis("Vertical");
    }
    public void Interaction()
    {
        if (PlayerHUD.Instance.GetteringUI.activeSelf == true)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                InteractionOn = true;
                if (InteractionOn)
                {
                    PlayerHUD.Instance.DeActivationGetteringUI();
                }

                PlayerHUD.Instance.LodingScreenUI();
            }
        }

    }
    public void Intventroy()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerHUD.Instance.InventoryScreenUi();
        }
    }
}
