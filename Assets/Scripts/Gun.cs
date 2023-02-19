using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform gunPoint;

    public float lastAttackTime = 0;
    public float attackCoolDown = 2;
    public float bullForce = 20f;
    private void Start()
    {
        if (gunPoint == null)
            gunPoint = GetComponentInChildren<GunPoint>().transform;
    }

    public void Fire()
    {
      if (Time.time - lastAttackTime > attackCoolDown)
        {
            lastAttackTime = Time.time;
            GameObject bullet = Instantiate(projectile, gunPoint.position, transform.rotation);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(gunPoint.up * bullForce, ForceMode.Impulse);
        }
    }
}
