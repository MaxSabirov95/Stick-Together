using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLocation : MonoBehaviour
{
    bool isPlayerIn;
    GameObject playerSprite;
    PlayerMovement playerRef;

    [SerializeField] private SpriteRenderer _textHide;
    [SerializeField] private SpriteRenderer _textUnHide;


    void Start()
    {
        playerSprite = GameObject.FindGameObjectWithTag("PlayerSprite");
        playerRef = FindObjectOfType<PlayerMovement>();
        _textHide.enabled = false;
        _textUnHide.enabled = false;
    }

    void Update()
    {
        if (isPlayerIn)
        {
            if (!playerRef.isPlayerHidding)
            {
                _textHide.enabled = true;
                _textUnHide.enabled = false;
            }
            else
            {
                _textUnHide.enabled = true;
                _textHide.enabled = false;
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
            _textHide.enabled = isPlayerIn;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerIn = false;
            _textHide.enabled = isPlayerIn;
        }
    }
}
