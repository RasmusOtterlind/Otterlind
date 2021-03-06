using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovePowerUp : MonoBehaviour
{
    private Rigidbody rigidBody;

    private Vector3 position;

    private GameObject pivotObject;
    [SerializeField]private float rotationSpeed = 15f;

    private bool update = false;
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
        if (update){
            //this.transform.localPosition = position;
            transform.RotateAround(pivotObject.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && GetComponent<PhotonView>().IsMine){
            DebugPrint("Collision with player");
            

            GetComponent<PhotonView>().RPC("FixPowerUp", RpcTarget.AllBuffered, collision.gameObject.GetComponent<PhotonView>().ViewID, Random.Range(-1f, 1f), Random.Range(0, 1f), Random.Range(-1f, 1f));
        }
    }

    [PunRPC]
    private void FixPowerUp(int photonViewId, float x, float y , float z)
    {
        position = new Vector3(x, y, z); 
        GameObject colliderObject = PhotonView.Find(photonViewId).gameObject;
        pivotObject = colliderObject;
       
        this.transform.SetParent(colliderObject.transform);
        
        position = position.normalized * 3;
        DebugPrint("Vector is: " + position);
        this.transform.localPosition = position;
        transform.LookAt(transform.parent);
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
        GetComponent<MeshCollider>().isTrigger = true;
        update = true;
    }
}


