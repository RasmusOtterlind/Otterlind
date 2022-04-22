using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSheet : MonoBehaviour
{
    private Dictionary<string,PowerUp> powerUps = new Dictionary<string, PowerUp>();
    // Start is called before the first frame update
    void Start()
    {
        PowerUp[] powerUpsInitArray = GetComponents<PowerUp>();
        foreach(PowerUp powerup in powerUpsInitArray)
        {
            powerUps.Add(powerup.GetKey(), powerup);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Should consider specifying powerups in some way here
    public void AddPowerUp(string powerUpKey)
    {
        //Testing shit code
        powerUps[powerUpKey].AddAdditionalPowerUp();
    }
}
