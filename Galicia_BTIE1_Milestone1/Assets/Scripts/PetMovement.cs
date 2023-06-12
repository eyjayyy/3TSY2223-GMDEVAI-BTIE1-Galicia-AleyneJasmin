using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    public Transform goal;
    float movementSpeed = 5;
    float rotationSpeed = 4;

    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        Vector3 targetDirection = lookAtGoal - transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * rotationSpeed);        

        if (Vector3.Distance(lookAtGoal, transform.position) > 2)
        {
            this.transform.position = Vector3.Lerp(transform.position, lookAtGoal, (movementSpeed/2) * Time.deltaTime);
        }
    }
}
