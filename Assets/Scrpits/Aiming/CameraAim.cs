using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraAim : MonoBehaviour
{
    [SerializeField] private LayerMask aimMask;
    [SerializeField] private PhotonView photonView;
    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, float.PositiveInfinity, aimMask))
            {
                transform.LookAt(hit.point);
            }
        }
        
    }
}
