using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealh;
    public float maxStamina = 100;
    public float minStamina = 0;
    public float currentStamina;
    public GameObject DeathScreen;


    private void Start()
    {
        currentHealh = maxHealth;
        currentStamina = maxStamina;
    }
    private void Update()
    {
        if (currentHealh <= 0)
            Die();
    }
    private void Die()
    {
        DeathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
}
