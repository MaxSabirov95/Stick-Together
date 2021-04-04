using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameItems : MonoBehaviour
{
    public GameObject[] items;
    public Weapon[] weapons;
    public GameObject player;

    private void Awake()
    {
        BlackBoard.allgameItems = this;
    }

    public void InstansiateItem(int num)
    {
        Instantiate(items[num], new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
    }

    //is this just for traps? if so, the added logic here is fine
    public void InstansiateWeapon(int num, int hp)
    {
        Weapon weapon = Instantiate(weapons[num], new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
        weapon.GetComponent<Weapon>().weaponHP = hp;

        //Alon: Here I add a Trap component to the weapon.
        // the Trap component comes with a RequiredComponent(typeof(Collider)) - so it will add a collider, 
        //if there isn't one already
        Trap trap = weapon.gameObject.AddComponent<Trap>();
        trap.trapDuration = 5; // this should be decided by the quality of the trap
    }

    public void InstansiateTrap(int num)
    {
        Weapon weapon = Instantiate(weapons[num], new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);

        //Alon: Here I add a Trap component to the weapon.
        // the Trap component comes with a RequiredComponent(typeof(Collider)) - so it will add a collider, 
        //if there isn't one already
        Trap trap = weapon.gameObject.AddComponent<Trap>();
        trap.trapDuration = 5; // this should be decided by the quality of the trap
    }
}
