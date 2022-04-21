using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CoinShieldPowerUp : PowerUp
{
    [SerializeField] private GameObject coinShield;
    [SerializeField] private Transform coinShieldTransform;
    private static string key = "CoinShield";

    public override void AddAdditionalPowerUp()
    {
        
        int viewID = PhotonNetwork.Instantiate(coinShield.name,Vector3.zero,Quaternion.identity).GetComponent<PhotonView>().ViewID;
        
    }

    public override string GetKey()
    {
        return key;
    }

    private void SetShieldParent()
    {

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
