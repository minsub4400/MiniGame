using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerCamera _playerCamera;
    public float MoveX;
    public float MoveZ;
    public bool InteractionOn = false;
    //public bool InventoryOnpen = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        UpdateMove();
        Interaction();
    }
    

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
                PlayerHUD.Instance.DeActivationGetteringUI();   
            }

            PlayerHUD.Instance.LodingScreenUI();
        }
        
    } 
}
