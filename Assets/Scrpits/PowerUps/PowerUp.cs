using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private int nUpgradesMax;


    //Forces children to have implementation
    public abstract void AddAdditionalPowerUp();

    
}