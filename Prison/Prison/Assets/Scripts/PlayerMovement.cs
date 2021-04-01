using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rB2D;
    Vector2 movement;
    //public Animator anim;
    public GameObject flashLight;

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
    }

    void PointAndClick()
    {

    }

    void FixedUpdate()
    {
        rB2D.MovePosition(rB2D.position+movement * moveSpeed * Time.fixedDeltaTime);
    }
}
