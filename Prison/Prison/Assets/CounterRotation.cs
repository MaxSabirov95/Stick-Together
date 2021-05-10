using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterRotation : MonoBehaviour
{

    void LateUpdate() //זמנית זה ישאר באפטדייט, אני רק מוודא שזה עובד 
    {
        transform.rotation = Quaternion.identity;
    }
}
