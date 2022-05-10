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
    private Camera camera;
    private Vector3 movementDirection;

    //camera
    private float xRotation = 0;

    private bool jumpPressed = false;
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
        camera = Camera.main;
        photonView = GetComponent<PhotonView>();
        rigidBody = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {

            forwardBackward = Input.GetAxisRaw("Vertical");
            sideStep = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                jumpPressed = true;
            }
            else
            {
                jumpPressed = false;
            }
            if (jumpPressed)
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

        }

    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            HandleMovement();
            //HandleRotation();

        }
        else
        { //We do not own this player
            return;
        }
    }

    private void HandleMovement()
    {
        
        movementDirection = new Vector3(sideStep, 0, forwardBackward);
        movementDirection = movementDirection.normalized;
        movementDirection = Quaternion.AngleAxis(camera.transform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        
        
        if (movementDirection.magnitude > 0.5f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rigidBody.velocity = (transform.forward * forwardBackward + transform.right * sideStep) * speed * 1.25f + new Vector3(0, rigidBody.velocity.y, 0);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movementDirection),150 * Time.deltaTime);
            }
            else
            {
                rigidBody.AddForce(movementDirection * 15);
                //rigidBody.velocity = movementDirection * speed + new Vector3(0, rigidBody.velocity.y, 0);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movementDirection), 150 * Time.deltaTime);
            }
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0), 150 * Time.deltaTime);

    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
