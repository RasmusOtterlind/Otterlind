using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestScript : MonoBehaviour
{
    private Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.Rotate(transform.up, 15 * Time.deltaTime);
        }
    }
}
