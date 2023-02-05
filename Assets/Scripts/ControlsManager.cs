using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMovement(InputValue value){
        CameraController.instance.OnMovement(value);
    }

    public void OnRotation(InputValue value){
        CameraController.instance.OnRotation(value);
    }

    public void OnCameraSpeedup(InputValue value){
        CameraController.instance.OnCameraSpeedup(value);
    }

    public void OnRightStickMouseEmulation(InputValue value){
        RaycastManager.instance.OnRightStickMouseEmulation(value);
    }

    public void OnPrimaryClick(InputValue value){
        RaycastManager.instance.OnPrimaryClick(value);
    }

    public void OnMousePosition(InputValue value){
        RaycastManager.instance.OnMousePosition(value);
    }

    public void OnSwitchDecorUp(InputValue value){
        CursorController.instance.OnSwitchDecorUp(value);
    }

    public void OnSwitchDecorDown(InputValue value){
        CursorController.instance.OnSwitchDecorDown(value);
    }

    public void OnDelete(InputValue value){
        CursorController.instance.OnDelete(value);
    }
}
