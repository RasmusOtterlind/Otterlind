using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Move : MonoBehaviour
{
    private PhotonView photonView;
    private float forwardBackward;
    private float sideStep;
    [SerializeField]private float speed = 5.0f;
    private Rigidbody rigidbody;
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
        rigidbody = GetComponent<Rigidbody>();

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
                rigidbody.AddForce(transform.up*1000);

            }

            transform.Translate((forwardBackward * transform.forward + sideStep * transform.right ) * Time.deltaTime * speed);
        }
        else
        { //Vi äger ej denna view
            return;
        }
    }
}
