using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float forwardSpeed = 10.0f;
    public float friction = 5.0f;
    //public float terminalVelocity = 20.0f;
    public float minStop = 0;

    private bool isDash;

    private float _horSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        _horSpeed = minStop;
        isDash = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Dash") !isDash){
            _horSpeed = forwardSpeed;
            isDash = true;
        } else{
            _horSpeed = minStop;
        }
    }
}
