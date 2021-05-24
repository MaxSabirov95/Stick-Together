using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigController : MonoBehaviour
{
    public Vector3 defualtRot;

    private void Update()
    {
        
    }

    public void RotateCamRig(float deg)
    {
        deg += 180f;
        defualtRot = new Vector3(defualtRot.x, deg, defualtRot.z);
        transform.localRotation = Quaternion.Euler(defualtRot);
    }
}
