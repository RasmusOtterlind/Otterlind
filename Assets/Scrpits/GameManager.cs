using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{

    [SerializeField] private bool debug = false;
    private float timeSinceStart = 0f;

    private float timeSinceCoin = 0f;
    [SerializeField]private float cooldownCoin = 10f;
    private int amountOfCoins = 0;
    public GameObject[] powerUpPickupList;
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
            DebugPrint("Time Since Coin: " + timeSinceCoin);

            if (timeSinceCoin  > cooldownCoin){
                
                SpawnRandomPowerUp();
                DebugPrint("Spawned a coin");
                timeSinceCoin = 0;
            }
        }
    }

    private void SpawnRandomPowerUp()
    {
        int  index = Random.Range(0, powerUpPickupList.Length);
        Vector3 coinVector = new Vector3(Random.Range(-45, 45), Random.Range(-5, 15), Random.Range(-45, 45));
        PhotonNetwork.Instantiate(powerUpPickupList[index].name, coinVector, Quaternion.identity);

    }
}
