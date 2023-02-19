using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public PlayerStats Playerstats;
    public float damage;

    private void Start()
    {
        Playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag =="player")
        {
            Playerstats.currentHealh -= damage;
            Destroy(gameObject);
        }
    }
}
