using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{

    private bool debug = true;
    private float timeSinceStart = 0f;

    private float timeSinceCoin = 0f;
    private float cooldownCoin = 0f;
    private int amountOfCoins = 0;

    private void DebugPrint(string debugString)
    {
        if (debug){
            Debug.Log(debugString);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DebugPrint("We have begun bitch");
        DebugPrint("Time is for server: " + PhotonNetwork.Time);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient){
            timeSinceStart += Time.deltaTime;
            timeSinceCoin += Time.deltaTime;

            DebugPrint("Time for server: " + timeSinceStart);
            if ((timeSinceStart % 100) == 0){
                DebugPrint("Time for server: " + timeSinceStart);

            }
        }
    }
}
