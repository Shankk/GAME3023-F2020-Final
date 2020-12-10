using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    List<int> wew;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    Rigidbody2D rigidBody;

    public Vector2 movementVector;
    // Update is called once per frame
    void Update()
    {
        
        movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementVector *= speed;
        rigidBody.velocity = movementVector;
        //Debug.Log("x: "+movementVector.x+" y: "+movementVector.y);
    }
}