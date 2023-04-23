using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplicatedDoorButt : MonoBehaviour
{
    public GameObject Door;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Door.SetActive(false);
    }
}
