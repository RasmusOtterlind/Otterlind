using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shoot : MonoBehaviour
{
    private PhotonView photonView;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform muzzle;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && photonView.IsMine)
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        PhotonNetwork.Instantiate(bullet.name, muzzle.position, muzzle.rotation);
    }
}
