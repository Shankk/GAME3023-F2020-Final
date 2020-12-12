using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public Vector3 TempBattleLocation = new Vector3(0,0,0);

    [SerializeField]
    float speed = 5;

    [SerializeField]
    Rigidbody2D rigidBody;

    public Vector2 movementVector;

    void Start()
    {
        //TempBattleLocation = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementVector *= speed;
        rigidBody.velocity = movementVector;
        //Debug.Log("x: "+movementVector.x+" y: "+movementVector.y);
    }
}