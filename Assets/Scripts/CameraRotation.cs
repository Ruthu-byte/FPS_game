using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public enum RotationAxes{
        MouseX = 0,
        MouseY = 1,
        MouseXandY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;

    public float horSensitivity = 6.0f;
    public float vertSensitivity = 6.0f;

    public float vertMax = 45.0f;
    public float vertMin = -45.0f;

    private float _rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null){
            body.freezeRotation = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxes.MouseX){
            transform.Rotate(0, Input.GetAxis("Mouse X") * horSensitivity, 0);
        }
        else if(axes == RotationAxes.MouseY){
            _rotationX -= Input.GetAxis("Mouse Y") * vertSensitivity;
            _rotationX = Mathf.Clamp(_rotationX, vertMin, vertMax);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else{
            _rotationX -= Input.GetAxis("Mouse Y") * vertSensitivity;
            _rotationX = Mathf.Clamp(_rotationX, vertMin, vertMax);

            float delta = Input.GetAxis("Mouse X") * horSensitivity;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
