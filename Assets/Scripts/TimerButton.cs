using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButton : MonoBehaviour
{
    public GameObject Door;
    public float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(ToggleDoor());
        }
    }

    private IEnumerator ToggleDoor()
    {
        Door.SetActive(false);
        yield return new WaitForSeconds(timer);
        Door.SetActive(true);
    }
}
