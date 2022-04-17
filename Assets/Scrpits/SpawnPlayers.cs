using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{

    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name,Vector3.zero, Quaternion.identity);
        Camera.main.transform.SetParent(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
