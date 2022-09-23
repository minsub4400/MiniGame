using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPostion : MonoBehaviour
{
    public PlayerInput player;
    Vector3 camerapos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camerapos = new Vector3(player.MoveX, 0, player.MoveZ).normalized;
        if (player.InteractionOn == true)
        {
            camerapos = Vector3.zero;
        }
        transform.position += camerapos * 2 * Time.deltaTime;
    }
}
