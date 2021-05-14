using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameItems : MonoBehaviour
{
    public Dictionary<weapon, Sprite> weaponToSprite;
    public List<Sprite> weaponsSprites;
    public Dictionary<item, Sprite> itemToSprite;
    public List<Sprite> itemsSprites;

    public Item[] items;
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

    public void InstansiateItem(int num, Transform _object)
    {
         Instantiate(items[num], player.transform.position, Quaternion.identity, _object);
    }

    //is this just for traps? if so, the added logic here is fine
    public void InstansiateWeapon(int num, int hp, Transform _object)
    {
        Weapon weapon = Instantiate(weapons[num], player.transform.position, Quaternion.identity, _object);
        weapon.GetComponent<Weapon>().weaponHP = hp;
    }

    public void InstansiateTrap(int num, Transform _object)
    {
        Weapon weapon = Instantiate(weapons[num], player.transform.position, Quaternion.identity, _object);

        //Alon: Here I add a Trap component to the weapon.
        // the Trap component comes with a RequiredComponent(typeof(Collider)) - so it will add a collider, 
        //if there isn't one already
        Trap trap = weapon.gameObject.AddComponent<Trap>();
        trap.trapDuration = 5; // this should be decided by the quality of the trap
    }
}
