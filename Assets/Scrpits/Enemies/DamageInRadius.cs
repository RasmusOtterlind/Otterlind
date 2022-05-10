using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
[RequireComponent(typeof(PhotonView))]
public class DamageInRadius : MonoBehaviour
{
    [SerializeField] private float damagePerSecond;
    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    private void OnTriggerStay(Collider other)
    {
        

        if(other.CompareTag("Player") && other.GetComponent<PhotonView>().IsMine){

            other.GetComponent<Destroyable>().Damage(damagePerSecond * Time.deltaTime);
        }
      
    }

}
