using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlock : MonoBehaviour
{
    public float Damage = 20;

    private PlayerStats stats;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stats = other.GetComponent<PlayerStats>();
            stats.currentHealh -= Damage;
        }
    }
}
