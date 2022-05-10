using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{

    [SerializeField] private bool debug = false;
    private float timeSinceStart = 0f;

    private float timeSinceCoin = 0f;
    [SerializeField] private float cooldownCoin = 10f;
    private float timeSinceEnemy = 0f;
    [SerializeField] private float cooldownEnemySpawn = 20f;
    private int amountOfCoins = 0;
    public GameObject[] powerUpPickupList;
    public GameObject[] enemyList;
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
            timeSinceEnemy += Time.deltaTime;
            DebugPrint("Time Since Coin: " + timeSinceCoin);

            if (timeSinceCoin  > cooldownCoin){
                
                SpawnRandomPowerUp();
                timeSinceCoin = 0;
            }

            if (timeSinceEnemy > cooldownEnemySpawn)
            {

                SpawnRandomEnemy();
                timeSinceEnemy = 0;
            }
        }
    }

    private void SpawnRandomPowerUp()
    {
        int  index = Random.Range(0, powerUpPickupList.Length);
        Vector3 coinVector = new Vector3(Random.Range(-100, 100), Random.Range(-5, 15), Random.Range(-100, 100));
        PhotonNetwork.Instantiate(powerUpPickupList[index].name, coinVector, Quaternion.identity);

    }

    private void SpawnRandomEnemy()
    {
        int index = Random.Range(0, enemyList.Length);
        Vector3 spawnVector = new Vector3(Random.Range(-100, 100), -9, Random.Range(-100, 100));
        PhotonNetwork.Instantiate(enemyList[index].name, spawnVector, Quaternion.identity);

    }
}
