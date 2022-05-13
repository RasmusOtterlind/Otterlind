using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Destroyable destroyable;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (GetComponent<PhotonView>().IsMine)
        {
            canvas.SetActive(true);
            healthSlider.maxValue = destroyable.healthPoints;
        }

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = destroyable.healthPoints;
    }
}
