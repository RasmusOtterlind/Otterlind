using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSheet : MonoBehaviour
{
    [SerializeField] private List<PowerUp> powerUps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Should consider specifying powerups in some way here
    public void AddPowerUp()
    {
        //Testing shit code
        powerUps.ToArray()[0].AddAdditionalPowerUp();
    }
}
