using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingBlock : MonoBehaviour
{
    public Transform pos1, pos2, startPos;
    public float speed;
    public float timeToStop;

    Vector3 nextPos;

    private void Start()
    {
        nextPos = startPos.position;
    }

    private void Update()
    {
        StartCoroutine(MovingPlatform());
    }
    public IEnumerator MovingPlatform()
    {
        if (transform.position == pos1.position)
        {
            yield return new WaitForSeconds(timeToStop);
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            yield return new WaitForSeconds(timeToStop);
            nextPos = startPos.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
