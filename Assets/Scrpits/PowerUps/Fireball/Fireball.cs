using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 20f;
    private PhotonView photonView;
    [SerializeField] private float timer = 10;
    private float timeSinceSpawned = 0f;
    private bool destroy = false;
    private float destroyTimer = 0;
    private ParticleSystem particleSystem;
    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (destroy)
            {
                destroyTimer += Time.deltaTime;
                if(destroyTimer > 2f)
                {
                    PhotonNetwork.Destroy(gameObject);

                }
                return;
            }
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
            timeSinceSpawned += Time.deltaTime;
            if(timeSinceSpawned > timer)
            {
                destroy = true;
            }
            
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (!photonView) return;
        if (photonView.IsMine)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Destroyable>().Damage(damage);
                destroy = true;
                transform.SetParent(other.transform);
                particleSystem.emissionRate = 600;
                
            }
            else if(other.CompareTag("Player"))
            {
                transform.SetParent(other.transform);
                destroy = true;
                particleSystem.emissionRate = 600;

            }
            else
            {
                transform.SetParent(other.transform);
                destroy = true;
                particleSystem.emissionRate = 0;
                
            }
        }
        
    }
}
