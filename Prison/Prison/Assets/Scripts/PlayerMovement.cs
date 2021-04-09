﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float walkingSpeed;
    [SerializeField] float runningSpeed;
    public Rigidbody2D rB2D;
    Vector2 movement;
    public float maxStamina;
    float currentStamina;
    public Bar staminaBar;
    bool isSprinting;
    //public Animator anim;
    public GameObject flashLight;

    private void Start()
    {
        moveSpeed = walkingSpeed;
        currentStamina = maxStamina;
        staminaBar.SetMaxSlider(maxStamina);
    }

    void Update()
    {
        //Alon
        PointAndClick();


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //anim.SetFloat("Horizontal", movement.x);
        //anim.SetFloat("Vertical", movement.y);
        //anim.SetFloat("Speed", movement.sqrMagnitude);
        //-- Brackeys TOP DOWN MOVEMENT in Unity Video

        if(movement.x > 0 && movement.y > 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0,315);
        }
        else if (movement.x < 0 && movement.y > 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (movement.x < 0 && movement.y < 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (movement.x > 0 && movement.y < 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        else if (movement.x < 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (movement.x > 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (movement.y < 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (movement.y > 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false; 
        }
        if (isSprinting && currentStamina > 0)
        {
            moveSpeed = runningSpeed;
            currentStamina -= Time.deltaTime;
            staminaBar.SetSlider(currentStamina);
        }
        else
        {
            moveSpeed = walkingSpeed;
            if (currentStamina < maxStamina)
            {
                currentStamina += 1*(Time.deltaTime * 0.25f);
                staminaBar.SetSlider(currentStamina);
            }
        }
    }

    void PointAndClick()
    {

    }

    void FixedUpdate()
    {
        rB2D.MovePosition(rB2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
