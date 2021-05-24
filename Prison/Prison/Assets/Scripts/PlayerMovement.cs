using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float walkingSpeed;
    [SerializeField] float runningSpeed;
    public Rigidbody2D rB2D;
    public int playerHP;
    Vector2 movement;
    public float maxStamina;
    float currentStamina;
    public Bar staminaBar;
    bool isSprinting;
    //public Animator anim;
    public GameObject flashLight;
    public bool isPlayerHidding;

    public Transform eyeTrans;

    public float stepRate;
    float currentStepDelta = 0;
    [SerializeField]
    float currentStepVolume;

    //Alon 23/05
    [SerializeField]
    Animator anim; //זה האנימטור ששולט על הדמות התלת מימדית
    [SerializeField]
    RigController rc;
    //Alon 23/05

    private void Start()
    {
        moveSpeed = walkingSpeed;
        currentStamina = maxStamina;
        staminaBar.SetMaxSlider(maxStamina);
    }

    void Update()
    {
        
        //Alon 23/05
        //movement.x = Input.GetAxisRaw("Horizontal");
        //התנועה לא צריכה לקפוץ ישר מ0 ל-1
        //חשוב להגיד גם שזה יוצר בעיות אם 2 הכיוונים לחוצים (כי אין נורמליזציה של הוקטור)
        //movement.y = Input.GetAxisRaw("Vertical");

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical") ; //זה לא מדוייק, אבל בגלל שאנחנו בעולם איזומטרי, התנועה למעלה/למטה היא קצת איטית יותר
        //Alon 23/05
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
            movement.y *= 0.5625f;


        //anim.SetFloat("Horizontal", movement.x);
        //anim.SetFloat("Vertical", movement.y);
        //anim.SetFloat("Speed", movement.sqrMagnitude);
        //-- Brackeys TOP DOWN MOVEMENT in Unity Video

        if (movement.x > 0 && movement.y > 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0,315);
            rc.RotateCamRig(315);
        }
        else if (movement.x < 0 && movement.y > 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 45);
            rc.RotateCamRig(45);
        }
        else if (movement.x < 0 && movement.y < 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 135);
            rc.RotateCamRig(135);
        }
        else if (movement.x > 0 && movement.y < 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 225);
            rc.RotateCamRig(225);
        }
        else if (movement.x < 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 90);
            rc.RotateCamRig(90);
        }
        else if (movement.x > 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 270);
            rc.RotateCamRig(270);
        }
        else if (movement.y < 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 180);
            rc.RotateCamRig(180);
        }
        else if (movement.y > 0)
        {
            flashLight.transform.rotation = Quaternion.Euler(0, 0, 0);
            rc.RotateCamRig(0);
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

        if (playerHP<=0)
        {
            Time.timeScale = 0;
            BlackBoard.inGameUI.deathPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            playerHP = 0;
        }
    }

    void PointAndClick()
    {

    }

    void FixedUpdate()
    {
        if (isPlayerHidding)
        {
            return;
        }
        else
        {
            // Alon 23/05
            //rB2D.MovePosition(rB2D.position + movement * moveSpeed * Time.fixedDeltaTime);
            transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);

            anim.SetFloat("Walk", (movement * moveSpeed).magnitude);
            // Alon 23/05

            currentStepDelta += (movement * moveSpeed * Time.fixedDeltaTime).magnitude;

            if (currentStepDelta >= stepRate)
            {
                currentStepDelta = 0;
                //play relevant step sound (decide on which type before this, somewhere else)
                //have some enums/straight-up-names of the directories to plug into the FMOD call

                AI_StateMachine.Instance.HearSomething(transform.position, currentStepVolume);


            }
        }
    }
}
