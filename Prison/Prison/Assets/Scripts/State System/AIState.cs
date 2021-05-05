using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AIState 
{
    public AI_StateMachine machine;
    public AI_State stateEnum;
    private AI_StateMachine newMachine;

    public AIState(AI_StateMachine newMachine, AI_State thisState)
    {
        machine = newMachine;
        stateEnum = thisState;
    }

    

    public virtual void DoOnStateStart()
    {

    }
    public virtual void DoUpdate()
    {

    }
    public virtual void DoFixedUpdate()
    {

    }
    public virtual void DoOnStateEnd()
    {

    }

    public virtual void OnAlerted(float alertAmount)
    {
        machine.alert += alertAmount;
        Debug.LogWarning("AI sensed something: " + alertAmount.ToString());
        if (machine.alert >= machine.maxAlert)
        {
            if ((int)stateEnum + 1 < AI_State.GetNames(typeof(AI_State)).Length)
                machine.LoadState(stateEnum + 1); // עובר למצב "חיפוש/חשד", מחפש אם יש שחקן באזור
            else
                machine.LoadState(0);
        }
        Debug.Log(stateEnum.ToString());
    }

}
