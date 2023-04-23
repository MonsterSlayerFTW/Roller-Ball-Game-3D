using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
   public GameObject lightSwitchPrefab;
    public bool IsOn = false;
    public AudioSource listener;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (IsOn == false)
            {
                lightSwitchPrefab.SetActive(true);
                IsOn = true;
                listener.Play();
            }
            else if (IsOn == true)
            {
                lightSwitchPrefab.SetActive(false);
                IsOn = false;
                listener.Play();
            }
        }
    }
}
