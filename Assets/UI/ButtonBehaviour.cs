using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    GameObject PlayerGO = null;
    public Vector3 TempBattleLocation = new Vector3(0,0,0);

    [SerializeField]
    protected BattleSystem battleSysRef = null;

    void Start()
    {
        PlayerGO = GameObject.FindWithTag("Player");
        Debug.Log("In Player Battle Position: " + PlayerGO.GetComponent<PlayerCharacterController>().TempBattleLocation);
        TempBattleLocation = PlayerGO.GetComponent<PlayerCharacterController>().TempBattleLocation;
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnPlayButtonClicked()
    {
        if(PlayerGO.tag == "Player")
        {
            PlayerGO.transform.position = new Vector3(0,0,0);
        }
        SceneManager.LoadScene("Overworld");
    }
    public void OnFightButtonClicked()
    {
        SceneManager.LoadScene("BattleScene");
        // Set The Player Character Active State To False Since we Are in Battle Mode
        if (PlayerGO.tag == "Player")
        {
            PlayerGO.transform.position = new Vector3(100, 0, 0);
        }
    }

    public void OnEscapeButtonClicked()
    {
        var EscapeRange = Random.Range(0, 100);
        if (EscapeRange > 30)
        {
            PlayerGO.transform.position = TempBattleLocation;
            SceneManager.LoadScene("Overworld");
        }
        else
        {
            Debug.Log("Failed To Escape! Escape Range: " + EscapeRange);
        }
    }

public void OnQuitGameClicked()
    {
        Application.Quit();
    }
}
