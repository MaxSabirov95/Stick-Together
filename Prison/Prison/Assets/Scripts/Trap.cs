using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(BoxCollider2D))] //בודר אם יש קוליידר אם לא מיצר אחד 
public class Trap : MonoBehaviour
{
    public float trapDuration;

    float previousSpeed;
    AIPath ai;

    private void Start()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        box.isTrigger = true;

        box.size = new Vector2(box.size.x / 2, box.size.y / 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("Triggered");
        if (collision.CompareTag("Enemy"))  // currently can only be the one enemy in the game 
                                        //(player doesnt trigger trap!)
        {
            ai = collision.GetComponent<AIPath>();
            if (ai)
            {
                //triggers trap. 
                //should be a function of emnemy.
                //also resetting the speed needs to happen within enemy logic so the trap can be destroyed
                //right after activation

                /// enemy.Trapped(trapDuration);
                /// Destroy(gameObject); 

                previousSpeed = ai.maxSpeed;
                ai.maxSpeed = 0;

                Invoke("ResetMaxSpeed", trapDuration);
            }
        }
    }

    void ResetMaxSpeed()
    {
        ai.maxSpeed = previousSpeed;
        Destroy(gameObject);
    }
}
