using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CoinShieldPowerUp : PowerUp
{
    [SerializeField] private GameObject coinShield;

    //The transform that the coins spin around
    [SerializeField] private Transform coinShieldTransform;
    public static string key = "CoinShield";
    private PhotonView photonView;
    public override void AddAdditionalPowerUp()
    {
        if (photonView.IsMine)
        {
            int viewID = PhotonNetwork.Instantiate(coinShield.name, Vector3.zero, Quaternion.identity).GetComponent<PhotonView>().ViewID;
            photonView.RPC(nameof(SetShieldParent), RpcTarget.AllBuffered, viewID);

        }
       
        
    }

    public override string GetKey()
    {
        return key;
    }
    [PunRPC]
    private void SetShieldParent(int viewId)
    {
        GameObject coinShield = PhotonView.Find(viewId).gameObject;
        coinShield.transform.SetParent(coinShieldTransform);
        coinShield.transform.localPosition = coinShieldTransform.forward * 3;
        coinShield.transform.LookAt(coinShieldTransform);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
}
