using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
[RequireComponent(typeof(PhotonView))]
public class Destroyable : MonoBehaviour
{
    [SerializeField] public float healthPoints;
    private PhotonView photonView;
    private float damageThreshHold = 10f;
    private float updateTreshold = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        if (photonView.IsMine)
        {
            healthPoints -= damage;
            if (healthPoints < 0)
            {
                if (gameObject.tag == "Player") Camera.main.transform.parent = null;
                PhotonNetwork.Destroy(gameObject);
            }
        }
        
        else if (!photonView.IsMine)
        {
            updateTreshold += damage;
            if(updateTreshold > damageThreshHold)
            {
                photonView.RPC("DamageWithUpdateThreshhold", RpcTarget.Others, damage);
                updateTreshold = 0;
            }
        }
    }
    [PunRPC]
    public void DamageWithUpdateThreshhold(float damage)
    {
        if (!photonView.IsMine)
            return;
        Damage(damage);
    }

   
    private void RPCDamage(float damage)
    {
        Damage(damage);
    }
    


}
