using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
[RequireComponent(typeof(PhotonView))]
public class Destroyable : MonoBehaviour
{
    [SerializeField] float HealthPoints;
    private PhotonView photonView;
    private float damageThreshHold = 0;
    
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
        HealthPoints -= damage;
        if(HealthPoints < 0 && photonView.IsMine)
        {
            if (gameObject.tag == "Player") Camera.main.transform.parent = null;
            PhotonNetwork.Destroy(gameObject);
        }
    }
    public void DamageWithUpdateThreshhold(float damage)
    {
        damageThreshHold += damage;
        if(damageThreshHold >= 5)
        {
            
        }
    }
    


}
