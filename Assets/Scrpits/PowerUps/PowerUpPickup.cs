using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Collider))]

public class PowerUpPickup : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && GetComponent<PhotonView>().IsMine)
        {
            collision.gameObject.GetComponent<PowerUpSheet>()?.AddPowerUp("Hej");
            PhotonNetwork.Destroy(gameObject);
        }
        
    }
}
