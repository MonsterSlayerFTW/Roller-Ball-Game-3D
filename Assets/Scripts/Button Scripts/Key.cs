using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public BallController ballController;

    public void Start()
    {
        ballController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ballController.hasKey = true;
            Destroy(gameObject);
        }
    }
}
