using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsRef : MonoBehaviour
{
    public GameObject[] regular;
    public GameObject[] traps;
    public GameObject weapon;

    public static SlotsRef instance;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
