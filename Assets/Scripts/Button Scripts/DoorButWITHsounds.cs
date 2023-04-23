using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButWITHsounds : MonoBehaviour
{
    public GameObject Door;
    public bool hasPlayedSound = false;
    public AudioSource Listener;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (hasPlayedSound == false)
            {
                Door.SetActive(false);
                hasPlayedSound = true;
                Listener.Play();
            }
        }

    }
}
