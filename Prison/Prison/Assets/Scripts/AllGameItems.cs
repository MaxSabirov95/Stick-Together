using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameItems : MonoBehaviour
{
    public Dictionary<weapon, Sprite> weaponToSprite;
    public List<Sprite> weaponsSprites;
    public Dictionary<item, Sprite> itemToSprite;
    public List<Sprite> itemsSprites;

    public GameObject[] items;
    public Weapon[] weapons;
    public GameObject player;

    //Enum.GetNames(typeof(MyEnum)).Length;
    private void Awake()
    {
        BlackBoard.allgameItems = this;
        weaponToSprite = new Dictionary<weapon, Sprite>();
        itemToSprite = new Dictionary<item, Sprite>();
        for (int i = 0; i < weapon.GetNames(typeof(weapon)).Length; i++)
        {
            weaponToSprite.Add((weapon)i,weaponsSprites[i]);
        }
        for (int i = 0; i < item.GetNames(typeof(item)).Length; i++)
        {
            itemToSprite.Add((item)i, itemsSprites[i]);
        }
    }

    public void InstansiateItem(int num)
    {
        Instantiate(items[num], player.transform.position, Quaternion.identity);
    }

    //is this just for traps? if so, the added logic here is fine
    public void InstansiateWeapon(int num, int hp)
    {
        Weapon weapon = Instantiate(weapons[num], player.transform.position, Quaternion.identity);
        weapon.GetComponent<Weapon>().weaponHP = hp;
    }

    public void InstansiateTrap(int num)
    {
        Weapon weapon = Instantiate(weapons[num], player.transform.position, Quaternion.identity);

        //Alon: Here I add a Trap component to the weapon.
        // the Trap component comes with a RequiredComponent(typeof(Collider)) - so it will add a collider, 
        //if there isn't one already
        Trap trap = weapon.gameObject.AddComponent<Trap>();
        trap.trapDuration = 5; // this should be decided by the quality of the trap
    }
}
