using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TextBoxAnimator : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI text;

    [SerializeField]
    [Range(0.001f,100000f)]
    float TextSpeed = 10;
    
    //public float TextTime = 0;

    IEnumerator animateTextRoutine = null;

    public void AnimateTextCharacterTurn(ICharacter whoseTurn)
    {
        AnimateText("It Is " + whoseTurn.name + "'s turn.");
    }

    public void AnimateTextCurrentTurn(string whoseTurnMsg)
    {
        AnimateText(whoseTurnMsg);
    }

    public void AnimateText(string message)
    {
        if(animateTextRoutine != null)
        {
            StopCoroutine(animateTextRoutine);
        }

        animateTextRoutine = AnimateTextRoutine(message);
        StartCoroutine(animateTextRoutine);
    }

    IEnumerator AnimateTextRoutine(string message)
    {
        Assert.IsTrue(TextSpeed > float.Epsilon);

        string currentMessage = "";
        
        for(int currentChar = 0; currentChar < message.Length; currentChar++)
        {
            currentMessage += message[currentChar];
            text.text = currentMessage;
            yield return new WaitForSeconds(1 / TextSpeed);
        }

        //TextTime = message.Length / 10;
        //Debug.Log("Message Delay: " + TextTime);
        animateTextRoutine = null;
    }

}
