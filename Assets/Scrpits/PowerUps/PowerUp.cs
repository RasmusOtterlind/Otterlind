using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected int nUpgradesMax;
    public abstract string GetKey();
    //Forces children to have implementation
    public abstract void AddAdditionalPowerUp();

    
}
