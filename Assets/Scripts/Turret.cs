using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float turretRange = 13f;
    [SerializeField] float turretRotationSpeed = 5f;

    private Transform playerTransform; //could be change to 'target'
    public Gun currentGun;

    private float fireRate;
    private float fireRateDelta;

    private void Start()
    {
        playerTransform= FindObjectOfType<BallController>().transform;
    }

    private void Update()
    {
        Vector3 playerGroundPos = new Vector3(playerTransform.position.x,
            transform.position.y, playerTransform.position.z);
        //Check if player is not in range, then do nothing
        if (Vector3.Distance(transform.position, playerGroundPos) > turretRange)
        {
            return; //do nothing because player is not in range
        }

        //Player in Range

        //roate Turret towards player
        Vector3 playerDirection = playerGroundPos - transform.position;
        float turretRotationStep = turretRotationSpeed* Time.deltaTime;
        Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection,turretRotationStep, 0f);
            transform.rotation = Quaternion.LookRotation(newLookDirection);

        fireRateDelta -= Time.deltaTime;
        if (fireRateDelta <= 0)
        {
            currentGun.Fire();
            fireRateDelta = fireRate;
        }
    }
}
