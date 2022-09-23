using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float MoveX;
    public float MoveZ;
    public bool InteractionOn = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        Interaction();
   
        UpdateMove();


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
        if(Input.GetKeyDown(KeyCode.E))
        {
            InteractionOn = true;
            if(InteractionOn)
            {
                
                UiManager.Instance.DeActivationGetteringUI();   
            }

            UiManager.Instance.LodingScreenUI();
        }
        
    }
}
