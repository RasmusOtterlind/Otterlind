using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CoinShieldPickup : PowerUpPickup
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PhotonView>().IsMine)
            {
                collision.gameObject.GetComponent<PowerUpSheet>().AddPowerUp(CoinShieldPowerUp.key);
            }
            if (GetComponent<PhotonView>().IsMine)
            {
                PhotonNetwork.Destroy(gameObject);
            }
            
            
        }
    }
}
