using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpeningCutscene : MonoBehaviour
{
    [SerializeField] private TextWriter _textWriter;
    public TextMeshProUGUI messageText;

    private void Start()
    {
        //messageText.text = "Hello World!";
        _textWriter.AddWriter(messageText, "1981, Russia. This is where are our story begins. " +
            "\n Samion, Roman, Nastia, Anton and Pavel a group of five people came to visit a gulag just for fun. " +
            "\n Everyone randomly disappeared except Samion and Pavel. " +
            "\n Pavel ran away from there while Samion was eager to find his friends.", 0.1f, true);
    }

    public void Continue()
    {
        this.gameObject.SetActive(false);
    }
}
