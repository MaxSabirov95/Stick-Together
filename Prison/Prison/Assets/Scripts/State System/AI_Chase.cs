using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI_Chase : AIState
{
    
    AIDestinationSetter destinationSetter;
    public AI_Chase(AI_StateMachine newMachine, AI_State thisState) : base(newMachine, thisState)
    {
    }

    public override void DoOnStateStart()
    {
        
        destinationSetter = machine.gameObject.GetComponent<AIDestinationSetter>();
        if (destinationSetter)

            destinationSetter.target = machine.playerMovement.gameObject.transform;
        else
            Debug.LogError("no destination setter found!");
        
    }

    public override void DoOnStateEnd()
    {
        if(destinationSetter)
        destinationSetter.target = machine.followTarget;
    }
}
