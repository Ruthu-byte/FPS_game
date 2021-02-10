using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public float speed = 24.0f;
    public float gravity = -9.8f;
    public float jumpSpeed = 35.0f;
    public float terminalVelocity = -25.0f;
    public float minFall = -1.5f;
    public float dashSpeed = 60.0f;

    private CharacterController _charController;
    private float _vertSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _vertSpeed = minFall;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        if(_charController.isGrounded){
            if(Input.GetButtonDown("Jump")){
                _vertSpeed = jumpSpeed;
            }
            else{
                _vertSpeed = minFall;
            }
        }
        else{
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if(_vertSpeed < terminalVelocity){
                _vertSpeed = terminalVelocity;
            }
        }

        if(Input.GetButtonDown("Dash")){
            movement *= dashSpeed;
        }

        movement.y = _vertSpeed;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _charController.Move(movement);
    }
}
