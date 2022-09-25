using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerCamera _playerCamera;
    public float MoveX;
    public float MoveZ;
    public bool InteractionOn = false;
    private Animator _animator;
    //public bool InventoryOnpen = false;
    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();


    }
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


            if (InteractionOn && PlayerHUD.Instance.GetteringUI.activeSelf == true)
            {
                _animator.SetBool("Attack", true);
                PlayerHUD.Instance.DeActivationGetteringUI();
            }

            PlayerHUD.Instance.LodingScreenUI();
        }
        
    } 
}
