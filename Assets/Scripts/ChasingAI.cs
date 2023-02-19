using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingAI : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;

    public float distance;
    public bool isAngered;

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        if(distance <= 5)
        {
            isAngered = true;
        }
        if(distance > 5)
        {
            isAngered = false;
        }

        if(isAngered)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        if(!isAngered)
        {
            agent.isStopped = true;
        }
    }
}
