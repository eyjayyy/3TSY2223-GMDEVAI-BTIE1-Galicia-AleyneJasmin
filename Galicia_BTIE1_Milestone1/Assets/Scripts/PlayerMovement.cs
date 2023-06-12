using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;

    void Update() 
    {
        // WASD movement
        float horizontalMovement = Input.GetAxis ("Horizontal");
        float verticalMovement = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);

        // Rotates player to direction of movement
        if (movement != Vector3.zero) 
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        transform.Translate (movement * movementSpeed * Time.deltaTime, Space.World);
    }   
}
