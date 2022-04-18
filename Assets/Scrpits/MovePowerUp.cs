using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovePowerUp : MonoBehaviour
{
    private Rigidbody rigidBody;
    private bool debug = true;
    public GameObject coinPrefab;

    private void DebugPrint(string debugString)
    {
        if (debug){
            Debug.Log(debugString);
        }
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.up * 600);
    }

    // Update is called once per frame
    void Update()
    {
        return;
    }
}


