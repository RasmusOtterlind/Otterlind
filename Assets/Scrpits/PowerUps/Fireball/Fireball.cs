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
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
            timeSinceSpawned += Time.deltaTime;
            if(timeSinceSpawned > timer)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Destroyable>().Damage(damage);
                PhotonNetwork.Destroy(gameObject);
            }
            else
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
        
    }
}
