using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
[RequireComponent(typeof(ParticleSystem))]
public class EnemyFlamethrower : MonoBehaviour
{
    [SerializeField] private float damage;
    private ParticleSystem particleSystem;
    private bool recharging = false;
    [SerializeField] private float rechargeTime;
    [SerializeField] private int particlesPersecond = 50; 
    private float timeSinceRecharge = 0f;

    
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!recharging)
        {
            timeSinceRecharge += Time.deltaTime;
            if (timeSinceRecharge > rechargeTime)
            {
               
                recharging = true;
                timeSinceRecharge = 0;
                particleSystem.emissionRate = 0;
            }
        }
        else if(recharging)
        {
            
            timeSinceRecharge += Time.deltaTime;
            if(timeSinceRecharge > rechargeTime)
            {
                
                particleSystem.emissionRate = particlesPersecond;
                timeSinceRecharge = 0;
                recharging = false;
            }
        }
       
       
    }

    private void OnParticleCollision(GameObject other)
    {
        
        if(other.gameObject.tag == "Player" && other.gameObject.GetComponent<PhotonView>().IsMine)
        {
            other.GetComponent<Destroyable>().Damage(damage);
        }
    }
}
