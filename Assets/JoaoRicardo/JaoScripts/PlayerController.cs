using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float runSpeed;

    public float groundDrag;

    [Header("Keys")]
    public KeyCode sprint = KeyCode.LeftShift;

    public Transform orient;

    float hInput;
    float vInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameDirector.Instance.canPlay) return;
        
        MyInput();
        SpeedControl();
        Sprint();

        rb.drag = groundDrag;
    }

    private void FixedUpdate()
    {
        if (!GameDirector.Instance.canPlay) return;
        
        MovePlayer();
    }

    private void MyInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orient.forward * vInput + orient.right * hInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    private void Sprint()
    {
        if (Input.GetKey(sprint))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }
}
