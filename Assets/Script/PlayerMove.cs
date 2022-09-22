using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 movevec;
    [SerializeField]
    private float moveSpeed = 1.0f;
    private PlayerInput input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        movevec = new Vector3(input.MoveX, 0, input.MoveZ).normalized;

        transform.position += movevec * moveSpeed * Time.deltaTime;
        
        if(movevec !=  Vector3.zero)
        {
            transform.rotation =Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(movevec.normalized),5);
        }
    }
}
