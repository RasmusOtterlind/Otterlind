using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Move : MonoBehaviour
{
    private PhotonView photonView;
    private float forwardBackward;
    private float sideStep;
    [SerializeField]private float speed = 5.0f;
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
            forwardBackward = Input.GetAxisRaw("Vertical");
            sideStep = Input.GetAxisRaw("Horizontal");

            transform.Translate((forwardBackward * transform.forward + sideStep * transform.right ) * Time.deltaTime * speed);
        }
        else
        { //Vi äger ej denna view
            return;
        }
    }
}
