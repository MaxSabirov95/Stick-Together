using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public enum AI_State { Wander, Search, Chase};

public class AI_StateMachine : MonoBehaviour
{
    public static AI_StateMachine Instance;

    public PlayerMovement playerMovement;

    public LayerMask playerMask;
    public Transform followTarget;
    public AIPath aiPath;

    public AIState currentState;

    public Rigidbody2D rb;

    public float alertRadius;

    public float alert; //how much attention is the player getting in currentState (100 = change in state)
    public float maxAlert = 100; //temp
    [SerializeField]
    float soundFalloffRate;
    [SerializeField]
    float alertDropoffRate;

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if(!playerMovement)
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            Debug.LogWarning("AI_StateMachine missing ref to Player movement - (FOUND with FindObjectOfType<PlayerMovement>()");
        }

        rb = GetComponent<Rigidbody2D>();

        alert = 0;
        LoadState(AI_State.Wander);
    }
    public void LoadState(AI_State newState)
    {
        alert = 0;

        if (currentState != null)
        currentState.DoOnStateEnd();

        switch (newState)
        {
            case AI_State.Wander:
                currentState = new AI_Wander(this, newState);
                break;
            case AI_State.Search:
                currentState = new AI_Search(this, newState);
                break;
            case AI_State.Chase:
                currentState = new AI_Chase(this, newState);
                break;
            default:
                Debug.LogError("no state was loaded!");
                break;
        }
        if(currentState != null)
        currentState.DoOnStateStart();
    }

    private void Update()
    {
        if (currentState == null)
            return;

        currentState.DoUpdate();
        
    }

    private void FixedUpdate()
    {
        if (currentState == null)
            return;

        currentState.DoFixedUpdate();

    }

    public void SeeSomething(Vector3 sourcePos, float lightAmount)
    {
        float n = lightAmount / (sourcePos - transform.position).magnitude;

        AddAlert(n);
    }
    public void HearSomething(Vector3 sourcePos, float volume)
    {
        float n = volume / (sourcePos - transform.position).magnitude;

        AddAlert(n);
    }
    
    //this is called be any of the public methods that modify the Alert score
    void AddAlert(float amount)
    {
        if (currentState == null)
            return;

        currentState.OnAlerted(amount);
    }

   
}
