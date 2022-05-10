using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class FireballPowerup : PowerUp
{
    [SerializeField] private GameObject fireball;

    public static string key = "Fireball";

    [SerializeField] private Transform muzzle;
    private int upgradeLevel = 1;
    private float startTime = 2f;
    private float shootTime;
    private float timer = 0f;
    private PhotonView photonView;
    public override void AddAdditionalPowerUp()
    {
        if (photonView.IsMine)
        {
            if(upgradeLevel < nUpgradesMax)
            {
                upgradeLevel++;
                shootTime = startTime / upgradeLevel;
            }
            
        }
        
    }

    public override string GetKey()
    {
        return key;
    }


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        shootTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(upgradeLevel >= 1 && photonView.IsMine)
        {
            timer += Time.deltaTime;
            if(timer > shootTime)
            {
                timer = 0;
                PhotonNetwork.Instantiate(fireball.name, muzzle.transform.position, muzzle.transform.rotation);
            }
        }
    }
}
