using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;
public class SpawnPlayers : MonoBehaviour
{

    public GameObject playerPrefab;
    [SerializeField] private Transform cameraLookAtTransform;
    [SerializeField] private Vector3 cameraOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name,Vector3.zero, Quaternion.identity);
        cameraLookAtTransform.SetParent(player.transform);
        cameraLookAtTransform.localPosition = cameraOffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
