using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Battary : MonoBehaviour
{
    public int power;
    private bool isPlayerOn;
    [SerializeField] private SpriteRenderer _text;

    //public Text pickUpText;

    //private void Awake()
    //{
    //    pickUpText = GameObject.FindGameObjectWithTag("Text - Pick Up").GetComponent<Text>();
    //}

    private void Start()
    {
        _text.enabled = false;
        //pickUpText.enabled = isPlayerOn;
    }

    private void Update()
    {
        if (isPlayerOn && Input.GetKeyDown(KeyCode.E))
        {
            BlackBoard.flashLight.AddPower(power);
            Destroy(gameObject);
        }     
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerOn = true;
            _text.enabled = true;
            //pickUpText.enabled = isPlayerOn;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerOn = false;
            _text.enabled = false;
            //pickUpText.enabled = isPlayerOn;
        }
    }
}
