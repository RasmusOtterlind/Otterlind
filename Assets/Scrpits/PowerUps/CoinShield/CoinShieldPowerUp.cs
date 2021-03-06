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
    private int counter = 0;
    private float offset = 5f;
    public override void AddAdditionalPowerUp()
    {
        if (photonView.IsMine && counter <= nUpgradesMax)
        {
            
            int viewID = PhotonNetwork.Instantiate(coinShield.name, Vector3.zero, Quaternion.identity).GetComponent<PhotonView>().ViewID;
            photonView.RPC(nameof(SetShieldParent), RpcTarget.AllBuffered, viewID ,counter);
            counter++;

        }
       
        
    }

    public override string GetKey()
    {
        return key;
    }
    [PunRPC]
    private void SetShieldParent(int viewId, int newCount)
    {
        counter = newCount;
        GameObject coinShield = PhotonView.Find(viewId).gameObject;
        coinShield.transform.SetParent(coinShieldTransform);
        if(counter == 0)
        {
            coinShield.transform.localPosition = Vector3.forward * offset + Vector3.up;
            coinShield.transform.LookAt(transform.position + Vector3.up);
        }
        else if (counter == 1)
        {
            coinShield.transform.localPosition = Vector3.forward * -offset + Vector3.up;
            coinShield.transform.LookAt(transform.position + Vector3.up);
        }
        else if (counter == 2)
        {
            coinShield.transform.localPosition = Vector3.right * offset + Vector3.up;
            coinShield.transform.LookAt(transform.position + Vector3.up);
        }
        else if (counter == 3)
        {
            coinShield.transform.localPosition = Vector3.right * -offset + Vector3.up;
            coinShield.transform.LookAt(transform.position + Vector3.up);

        }

        coinShield.transform.LookAt(coinShield.transform.position - coinShield.transform.forward);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
}
