using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject player;
    bool IsCameraAttached = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AssignRigiBody2D();
    }

    void AssignRigiBody2D()
    {
        if(!IsCameraAttached)
        {
            player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                GetComponent<SpringJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
                gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-13);
                IsCameraAttached = true;
            }
            else
            {
                Debug.Log("Error!, Cant Assign Player To Camera!");
            }
        }
        
    }
}
