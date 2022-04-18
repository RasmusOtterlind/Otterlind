using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Move : MonoBehaviour
{
    private PhotonView photonView;
    private float forwardBackward;
    private float sideStep;
    [SerializeField] private float speed = 5.0f;
    private Rigidbody rigidBody;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundChecker;

    //camera
    private float xRotation = 0;


    private bool firstJump = false;
    // Start is called before the first frame update
    private bool debug = true;

    private void DebugPrint(string debugString)
    {
        if (debug){
            Debug.Log(debugString);
        }
    }

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        rigidBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            HandleMovement();
            HandleRotation();
            
        }
        else
        { //Vi äger ej denna view
            return;
        }
    }

    private void HandleMovement()
    {
        forwardBackward = Input.GetAxisRaw("Vertical");

        sideStep = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (Physics.CheckSphere(groundChecker.position, 0.2f, groundMask, QueryTriggerInteraction.Ignore))
            {

                rigidBody.AddForce(transform.up * 600);
                firstJump = true;
            }
            else if (firstJump)
            {
                rigidBody.AddForce(transform.up * 600);
                firstJump = false;
            }

        }
        transform.Rotate(0, sideStep * 80 * Time.deltaTime, 0, relativeTo: Space.World);
        rigidBody.velocity = transform.forward * speed * forwardBackward + new Vector3(0, rigidBody.velocity.y, 0);
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * 5;
        float mouseY = Input.GetAxis("Mouse Y") * 5;
        transform.Rotate(mouseY * 50 * Time.deltaTime, 0, 0, relativeTo: Space.World);
        transform.Rotate(0, mouseX * 50 * Time.deltaTime, 0, relativeTo: Space.World);

    }
}
