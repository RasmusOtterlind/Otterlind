using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Rotate : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 90;

    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        
    }
}
