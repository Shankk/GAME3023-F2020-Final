using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightScene : MonoBehaviour
{
    float timeCheck = 0;
    bool isMoving = true;
    float moveX, moveY;
    public GameObject PlayerGO = null;
    public PlayerCharacterController movement = null;

    void Update()
    {
        if (PlayerGO == null)
        {
            PlayerGO = GameObject.FindWithTag("Player");
            movement = PlayerGO.GetComponent<PlayerCharacterController>();
        }
        // Debug.Log("x: " + movement.movementVector.x+ " y: " + movement.movementVector.y);
        moveX = movement.movementVector.x;
        moveY = movement.movementVector.y;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        int WeightedRange = Random.Range(0, 100);
        timeCheck += Time.deltaTime; 

        if (timeCheck >= 1 && (moveX > 0 || moveY > 0))
        {

            if (collision.tag == "Player")
            {
                Debug.Log("Entering");
                if (WeightedRange <= 25)
                {
                    // Set The Location Of Where We Entered The Battle From
                    GameObject.FindWithTag("Player").GetComponent<PlayerCharacterController>().TempBattleLocation = GameObject.FindWithTag("Player").transform.position;
                    Debug.Log("Start Battle Position: " + GameObject.FindWithTag("Player").GetComponent<PlayerCharacterController>().TempBattleLocation);
                    SceneManager.LoadScene("BattleScene");
                    // Set The Player Character Active State To False Since we Are in Battle Mode
                    PlayerGO.transform.position = new Vector3(100, 0, 0);
                }
            }
            timeCheck = 0;
        }
    }
}
