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
                if(Physics.CheckSphere(groundChecker.position, 0.2f, groundMask, QueryTriggerInteraction.Ignore))
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
        else
        { //Vi äger ej denna view
            return;
        }
    }
}
