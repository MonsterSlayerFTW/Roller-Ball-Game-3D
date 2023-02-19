using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    public Rigidbody rigidbody;
    public AudioSource listener;
    public bool canPlay = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canPlay == true)
        {
            rigidbody.constraints = RigidbodyConstraints.None;
            listener.Play();
            canPlay = false;
        }
    }
}
