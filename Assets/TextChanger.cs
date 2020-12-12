using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
 
    private TextMeshProUGUI gameOverMsg;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMsg = GetComponent<TextMeshProUGUI>();
        textChanger();
    }

    void textChanger()
    {
        var RandNum = Random.Range(0, 4);

        if(RandNum == 0)
            gameOverMsg.text = "Git Gud Bruh";
        else if (RandNum == 1)
            gameOverMsg.text = "RIP Clyde";
        else if (RandNum == 2)
            gameOverMsg.text = "Next time don't troll";
        else
            gameOverMsg.text = "If I were a teacher i'd give this a 100!";
    }
}
