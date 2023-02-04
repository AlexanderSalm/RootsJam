using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float speedMod;
    public float rotationSpeed;
    public float rotationSpeedMod;
    public float cameraSmoothness;
    public float rotationSmoothness;

    private GameObject cameraPivot;
    private Vector2 rawMovement;
    private float rawRotation;

    private Vector3 targetPosition;
    private Vector3 targetRotation;
    private Vector3 currentRotation;

    private bool speedupHeld;
    // Start is called before the first frame update
    void Start()
    {
        cameraPivot = transform.GetChild(0).gameObject;

        targetPosition = transform.position;
        targetRotation = cameraPivot.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //Handle position
        float speedupFactor = 1;
        if(speedupHeld) speedupFactor = speedMod;
        Vector3 movementVector = new Vector3(rawMovement.x, 0, rawMovement.y);

        Vector3 cameraRotation = cameraPivot.transform.localEulerAngles;
        float xFactor =  Mathf.Sin((cameraRotation.y) * Mathf.Deg2Rad);
        float zFactor = Mathf.Cos((cameraRotation.y) * Mathf.Deg2Rad);
        movementVector = new Vector3(movementVector.z * xFactor + movementVector.x * zFactor, 0, movementVector.z * zFactor + -movementVector.x * xFactor);
        
        targetPosition += movementVector * speed * Time.deltaTime * speedupFactor;

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSmoothness * Time.deltaTime);

        //Handle rotation
        speedupFactor = 1;
        if(speedupHeld) speedupFactor = rotationSpeedMod;
        targetRotation += new Vector3(0, rawRotation, 0) * rotationSpeed * Time.deltaTime * speedupFactor;
        currentRotation = Vector3.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSmoothness);
        cameraPivot.transform.localEulerAngles = currentRotation;
    }

    public void OnMovement(InputValue value){
        rawMovement = value.Get<Vector2>();
    }

    public void OnRotation(InputValue value){
        rawRotation = value.Get<float>();
    }

    public void OnCameraSpeedup(InputValue value){
        speedupHeld = value.Get<float>() == 1.0f;
    }
}
