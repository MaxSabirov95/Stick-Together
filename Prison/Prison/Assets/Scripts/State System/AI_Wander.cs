using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AI_Wander : AIState
{
    LayerMask layerMask;
    Collider2D wanderZone;
    public AI_Wander(AI_StateMachine newMachine, AI_State aI_State) : base(newMachine, aI_State)
    {
    }

    public override void DoOnStateStart()
    {
        layerMask = (LayerMask)4096;
        Collider2D hit = Physics2D.OverlapArea((Vector2)machine.gameObject.transform.position - Vector2.one*10f, (Vector2)machine.gameObject.transform.position + Vector2.one * 10f, layerMask);
        
            if(hit.CompareTag("WanderZone"))
            {
                wanderZone = hit;
                Debug.LogError("wander zone detected!");

            }
        
        if(!wanderZone)
        {
            Debug.LogError("no wander zone detected");
        }
    }

    public override void DoUpdate()
    {
    }
    public override void DoFixedUpdate()
    {
        if(Vector2.Distance((Vector2)machine.gameObject.transform.position, (Vector2)machine.followTarget.transform.position) <= machine.aiPath.endReachedDistance)
        //if(machine.aiPath.remainingDistance <= 1f)
        {
            Vector2 random = (Vector2)machine.gameObject.transform.position + new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            machine.followTarget.position = wanderZone.ClosestPoint(random);
        }
    }

}
