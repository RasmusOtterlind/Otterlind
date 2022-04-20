using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CoinShieldPowerUp : PowerUp
{
    [SerializeField] private GameObject coinShield;
    public override void AddAdditionalPowerUp()
    {
        PhotonNetwork.Instantiate(coinShield.name,Vector3.zero,Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
