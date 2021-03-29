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

    public void InstansiateWeapon(int num, int hp)
    {
        Weapon weapon = Instantiate(weapons[num], new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
        weapon.GetComponent<Weapon>().weaponHP = hp;
    }
}
