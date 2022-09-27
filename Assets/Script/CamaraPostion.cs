using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPostion : MonoBehaviour
{

    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
            transform.position = new Vector3(Player.position.x, 15.47713f, Player.position.z-7.9f);
            

        

        //if(player.transform.position.z < )
        
       


            //camerapos = new Vector3(player.MoveX, 0, player.MoveZ).normalized;
            //if (player.InteractionOn == true)
            //{
            //    camerapos = Vector3.zero;
            //}
            //transform.position += camerapos * 5 * Time.deltaTime;
        
        




    }


}
