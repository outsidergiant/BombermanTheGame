using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastWaveBehaviour : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Brick"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
