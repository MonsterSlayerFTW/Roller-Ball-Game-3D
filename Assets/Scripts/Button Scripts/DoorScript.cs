using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject doorOpen, doorClose;
    public BallController BallController;

    public void Start()
    {
        BallController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (BallController.hasKey == true)
            {
                doorOpen.SetActive(true);
                doorClose.SetActive(false);
            }

        }
        
    }
}
