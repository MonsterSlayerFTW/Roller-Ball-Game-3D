using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 2;
    public float sprint = 4;
    public float jumpStamina = 5;
    public float MAXspeed;
    public float JumpSpeed;

    public float lastRegen;
    public float staminaRegenSpeed;
    public float staminaRegenAmount;

    public bool isGrounded;
    public bool isRunning = false;
    private Rigidbody rigid;
    private PlayerStats stats;

    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        MAXspeed = speed;
        stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        RegenStamina();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        else
        {
            isRunning = false;
            speed = 2;
        }
        if (speed > MAXspeed && !isRunning)
        {
            speed = 2;
        }

        if (stats.currentStamina <= 0)
        {
            sprint = 2;
            stats.currentStamina = stats.minStamina;
        }

        else if (stats.currentStamina > 0)
        {
            sprint = 4;
        }
;

        // This section controlls movement and jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if(stats.currentStamina >= 10)
            rigid.AddForce(Vector3.up * JumpSpeed);
            stats.currentStamina -= jumpStamina;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rigid.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigid.AddForce(-Vector3.right * speed);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rigid.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigid.AddForce(-Vector3.forward * speed);
        }
        
    }

    // OnTriggerStay and OnTriggerEnter deals with checking if where on the ground when jumping.
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
            isGrounded = true;
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
            isGrounded = false;
    }

    // This section controlls running and stamina regen
    public void Running()
    {
        isRunning = true;
        speed = sprint;
        stats.currentStamina -= 10 * Time.deltaTime;
    }

    void RegenStamina()
    {
        if (Time.time - lastRegen > staminaRegenSpeed && !isRunning && stats.currentStamina < stats.maxStamina)
        {
            stats.currentStamina += staminaRegenAmount;
            lastRegen = Time.time;
        }
       
    }
}
