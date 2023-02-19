using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerStats stats;
    public Image healthImage, staminaImage;


    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        healthImage.fillAmount = stats.maxHealth / 100;
        staminaImage.fillAmount = stats.maxStamina / 100;
    }


    private void Update()
    {
        healthImage.fillAmount = stats.currentHealh / 100;
        staminaImage.fillAmount = stats.currentStamina / 100;
    }
}
