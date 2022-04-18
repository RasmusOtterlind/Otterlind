using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovePowerUp : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private bool debug = false;


    private void DebugPrint(string debugString)
    {
        if (debug){
            Debug.Log(debugString);
        }
    }

    void Start()
    {
        DebugPrint("Hello we added coin booooi");
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.up * 600);
    }

    // Update is called once per frame
    void Update()
    {
        return;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){
            Debug.Log("Collision with player");
            PhotonNetwork.Destroy(this.GetComponent<PhotonView>());
        }
    }
}


