using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPostion : MonoBehaviour
{
    public PlayerInput player;
    Vector3 camerapos;
    private float TransformMinX = -30f;
    private float TransformMaxX = 20.7f;
    private float TransformMinZ = -35.7f;
    private float TransformMaxZ = 15.7f;
    public Transform Player;
    float changeCameraMaxX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
            transform.position = new Vector3
                (Mathf.Clamp(transform.position.x, TransformMinX, TransformMaxX), transform.position.y, Mathf.Clamp(transform.position.z, TransformMinZ, TransformMaxZ));
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
