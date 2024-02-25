using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Keys")]
    public KeyCode sprint = KeyCode.LeftShift;

    public Transform orient;

    private AudioSource steps;

    float hInput;
    float vInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        steps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameDirector.Instance.canPlay) return;
        
        MyInput();
        SpeedControl();

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

        print(moveDirection.magnitude);

        if(moveDirection.magnitude > 0)
        {
            steps.pitch = Random.Range(0.5f, 1.5f);
            steps.Play();
        }
        else
        {
            steps.Stop();
        }
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
}
