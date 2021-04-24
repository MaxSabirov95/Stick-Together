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
        _textWriter.AddWriter(messageText, "1:47 AM" + 
            "\n \n Officer: 102." + 
            "\n Woman: My Kids are gone! I wasn't home for 3 hours and now they are gone!" + 
            "\n Officer: Miss, Can you repeat that sentence?" +
            "\n Woman: My kids are gone!" +
            "\n Officer: When was the last time you saw them?" +
            "\n Woman: 3 hours ago, My husband and I went to a restaurant and they were already in their beds, we came back 15 minutes ago and they are not there." +
            "\n Officer: Do you have any clue where they might have went?"+
            "\n Woman: I heard my little girl saying to her brother something about an old gulag, I think they might have talked about Kashtan cause it isn't far from here." +
            "\n Officer: What are their names?" +
            "\n Woman: Nastia and Roman Zaitzev, Nastia is 17 years old and Roman is 18." +
            "\n Officer: Miss don't worry I've already sent some officers there." +
            "\n \n 3 hours earlier...", 0.1f, true);
    }

    public void Continue()
    {
        this.gameObject.SetActive(false);
    }
}
