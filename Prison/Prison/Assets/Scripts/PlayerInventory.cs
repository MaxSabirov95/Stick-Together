using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //id0_Bottle;
    //id1_Iron;
    //id2_Mask;
    //id3_Screw;
    //id4_Wood;
    //id5_BaseBall;
    //id6_BearTrap;
    //id7_FlashBang;
    public int[] itemsId;

    private void Start()
    {
        itemsId = new int[8];
    }

    private void Awake()
    {
        BlackBoard.playerInventory = this;
    }
}
