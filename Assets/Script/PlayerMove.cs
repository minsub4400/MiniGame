using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 movevec;
    [SerializeField]
    private float moveSpeed = 1.0f;
    private PlayerInput input;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        movevec = new Vector3(input.MoveX, 0, input.MoveZ).normalized;
        if (input.InteractionOn == true)
        {
            movevec = Vector3.zero;
        }
        transform.position += movevec * moveSpeed * Time.deltaTime;


        _animator.SetBool("Run", movevec != Vector3.zero);

        if (movevec != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movevec.normalized), 5);
        }
    }
}
