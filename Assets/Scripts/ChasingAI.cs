using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingAI : MonoBehaviour
{
    [SerializeField] private SphereCollider triggerSphere;
    [SerializeField] private bool MoveRigidBody = true;
    [SerializeField] private float RgbRotationSpeed = 5f;
    [SerializeField] private float TriggerRadius = 5f;
    [SerializeField] private float ChaseSpeed = 5f;
    [SerializeField] private float ChaseDelay = 1f;

    private Transform localTrans;
    private bool detected = false;
    private Transform targetTrans;
    private Vector3 targetPos;
    private Rigidbody localRgb;

    void Start()
    {
        localRgb= GetComponent<Rigidbody>();
        localTrans = GetComponent<Transform>();

        if (!triggerSphere) triggerSphere = GetComponent<SphereCollider>();
        if (triggerSphere)
            triggerSphere.radius = TriggerRadius;

        targetTrans = null;
    }

    private void Update()
    {
        if (detected && targetTrans != null)
        {
            //ChasePlayer
            Chase(targetTrans);
        }
    }

    void Chase(Transform _target)
    {
        var Speed = ChaseSpeed;

        targetPos = _target.position;
        targetPos.y = localTrans.position.y;

        //Move Rigibody
        if (MoveRigidBody)
        {
            RotateRgb(_target);
            localRgb.MovePosition(localRgb.position + localTrans.forward * Speed * Time.deltaTime);
        }
    }

    private void RotateRgb(Transform _target)
    {
        Vector3 localTarget = localTrans.InverseTransformPoint(_target.position);

        float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        Vector3 eulerAngleVelocity = new Vector3(0, angle, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * RgbRotationSpeed);
        localRgb.MoveRotation(localRgb.rotation * deltaRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (detected) return;
        //Follow only if the detected one is the PLayer
        if (other.CompareTag("Player"))
        {
            Debug.Log("Detected: " + other.name);
            detected = true;
            StartCoroutine(ActiveChasing(other.transform, ChaseDelay));
        }
    }

    IEnumerator ActiveChasing(Transform other, float _waitSec = 1f)
    {
        yield return new WaitForSeconds(_waitSec);
        targetTrans = other;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        //Uses the same var you use to draw your overlap sphere to whatever
        Gizmos.DrawWireSphere(this.transform.position, TriggerRadius);
    }

    public void StopChasing()
    {
        detected = false;
    }

}
