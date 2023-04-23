using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject doorButton;
    public BallController BallController;

    public void Start()
    {
        BallController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
    }


}
