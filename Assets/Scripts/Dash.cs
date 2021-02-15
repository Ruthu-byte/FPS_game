using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code comes form https://answers.unity.com/questions/824891/how-do-i-script-the-player-character-to-dash.html

public class Dash : MonoBehaviour
{
    public Vector3 movementDirection;

    public const float maxDashTime = 1.0f;
    public float dashDistance = 10;
    public float dashStoppingSpeed = 0.1f;
    float currentDashTime = maxDashTime;
    float dashSpeed = 6;
    CharacterController controller;


    private void Awake(){
        controller = GetComponent<CharacterController>();
    }

    void Update(){
        if(Input.GetButtonDown("Dash")){
            currentDashTime = 0;
        }
        if(currentDashTime < maxDashTime){
            movementDirection = transform.forward *dashDistance;
            currentDashTime += dashStoppingSpeed;
        }
        else{
            movementDirection = Vector3.zero;
        }
        controller.Move(movementDirection * Time.deltaTime * dashSpeed);
    }
}
