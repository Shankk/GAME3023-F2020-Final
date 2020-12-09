using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
   
public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

public void OnPlayButtonClicked()
    {
        if(GameObject.FindWithTag("Player") == true)
        {
            GameObject.FindWithTag("Player").GetComponentInChildren<Canvas>().enabled = true;
            GameObject.FindWithTag("Player").transform.position = new Vector3(0,0,0);
        }

        SceneManager.LoadScene("Overworld");
        
    }
    public void OnFightButtonClicked()
    {
        SceneManager.LoadScene("BattleScene");
        // Set The Player Character Active State To False Since we Are in Battle Mode
        if (GameObject.FindWithTag("Player") == true)
        {
            GameObject.FindWithTag("Player").GetComponentInChildren<Canvas>().enabled = false;
            GameObject.FindWithTag("Player").transform.position = new Vector3(100, 0, 0);
        }
        //GetComponentInParent<Canvas>().gameObject.SetActive(false);
        //GetComponentInParent<PlayerCharacterController>().gameObject.transform.position = new Vector3(100,0,0);
    }

public void OnQuitGameClicked()
    {
        Application.Quit();
    }
}
