using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Search : AIState
{

    public float searchRate; //should be effected by external elements

    public AI_Search(AI_StateMachine newMachine, AI_State thisState) : base(newMachine, thisState)
    {
    }

    public override void DoOnStateStart()
    {
        //base.DoOnStateStart();
        Debug.LogWarning("Searching State!");
        machine.rb.isKinematic = true;
    }
    public override void DoOnStateEnd()
    {
        machine.rb.isKinematic = false;
    }

    public override void DoFixedUpdate()
    {
        float dist = Vector3.Distance(machine.transform.position, machine.playerMovement.transform.position);
        //Check 1) is player in radius?
        if (dist > machine.alertRadius)
        {
            return; //perhaps too danderous
        }

        if(Physics2D.BoxCast(machine.transform.position, Vector2.one * 2f, 0, Vector2.up, 10, machine.playerMask))
        {
            Debug.LogWarning("Player found!");
        }
        else
        {
            //machine.transform.LookAt(PlayerMovement.Instance.transform); bad for 2D
        }
        //Player is IN RANGE of detection.
        //Check 2) Test for [volume modified by distance]. Did sound pass thresholds?
        //if()

        
    }

    

    //public override void SensedSomething(float amountOfSense)
    //{
    //    base.SensedSomething(amountOfSense); //adds the amount to the machine.sense

    //    Debug.LogWarning("Wandering AI sensed something: " + amountOfSense.ToString());
    //    if (machine.sense >= machine.maxSense)
    //    {
    //        machine.LoadState(AI_State.Chase); // עובר למצב "חיפוש/חשד", מחפש אם יש שחקן באזור
    //    }
    //}
}
