using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PhotonView))]

public class SimpleNavMeshScrip : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private PhotonView photonView;

    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void MoveTo(Vector3 point)
    {
        navMeshAgent.destination = point;
    }
    private void FindTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    //We only want to calculate a path on one client
    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            if (target)
            {
                MoveTo(target.transform.position);
            }
            else
            {
                FindTarget();
            }
        }
        
    }
}
