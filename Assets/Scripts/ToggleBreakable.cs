using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBreakable : MonoBehaviour
{
    public GameObject wall, brokenwall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            wall.SetActive(false);
            Instantiate(brokenwall, transform.position, transform.rotation);
        }
    }
}
