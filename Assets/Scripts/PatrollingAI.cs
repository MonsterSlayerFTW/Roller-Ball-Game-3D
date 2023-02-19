using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingAI : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    public int CurrentPoint;

    void Start()
    {
        CurrentPoint = 0;
    }

    void Update()
    {
        if (transform.position != points[CurrentPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[CurrentPoint].position, speed * Time.deltaTime);
        }
        else
        {
            CurrentPoint = (CurrentPoint + 1) % points.Length;
        }
    }
}
