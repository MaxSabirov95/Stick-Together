using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideLocation : MonoBehaviour
{
    bool isPlayerIn;
    GameObject playerSprite;
    PlayerMovement playerRef;

    public Text pickUpText;

    private void Awake()
    {
        pickUpText = GameObject.FindGameObjectWithTag("Text - Hide").GetComponent<Text>();
    }

    void Start()
    {
        playerSprite = GameObject.FindGameObjectWithTag("PlayerSprite");
        playerRef = FindObjectOfType<PlayerMovement>();
        pickUpText.enabled = isPlayerIn;
    }

    void Update()
    {
        if (isPlayerIn)
        {
            if (!playerRef.isPlayerHidding)
            {
                pickUpText.text = "Press 'E' To Hide";
            }
            else
            {
                pickUpText.text = "Press 'E' To UnHide";
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!playerRef.isPlayerHidding)
                {
                    playerSprite.SetActive(false);
                    playerRef.isPlayerHidding = true;
                    playerRef.flashLight.SetActive(false);
                }
                else
                {
                    playerSprite.SetActive(true);
                    playerRef.isPlayerHidding = false;
                    playerRef.flashLight.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerIn = true;
            pickUpText.enabled = isPlayerIn;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerIn = false;
            pickUpText.enabled = isPlayerIn;
        }
    }
}
