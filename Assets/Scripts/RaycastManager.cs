using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastManager : MonoBehaviour
{
    public static RaycastManager instance;

    public GameObject cursor;

    public float rightStickSpeed;

    public bool groundRaycastSuccess;
    public RaycastHit groundHit;

    public bool gardenItemSuccess;
    public RaycastHit gardenItemHit;

    private Vector2 rawRightStick;
    private Vector2 mouseOffset;
    private Vector2 mousePosition;

    private bool clicking;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        mouseOffset += rawRightStick * rightStickSpeed * Time.deltaTime * new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        cursor.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0) + new Vector3(mouseOffset.x, mouseOffset.y, 0);

        Ray ray = CameraController.instance.GetCamera().ScreenPointToRay(new Vector2(cursor.transform.position.x, cursor.transform.position.y));
        Debug.DrawRay(ray.origin, ray.direction * 250.0f);
        int layerMask = 1 << 6;
        groundRaycastSuccess = Physics.Raycast(ray, out groundHit, 250, layerMask);

        ray = CameraController.instance.GetCamera().ScreenPointToRay(new Vector2(cursor.transform.position.x, cursor.transform.position.y));
        Debug.DrawRay(ray.origin, ray.direction * 250.0f);
        layerMask = 1 << 7;
        gardenItemSuccess = Physics.Raycast(ray, out gardenItemHit, 250, layerMask);

        if(clicking){
            clicking = false;
            CursorController.instance.Click();
        }
    }

    public void OnRightStickMouseEmulation(InputValue value){
        rawRightStick = value.Get<Vector2>();
    }

    public void OnPrimaryClick(InputValue value){
        clicking = value.Get<float>() == 1.0f;
    }

    public void OnMousePosition(InputValue value){
        mousePosition = value.Get<Vector2>();
    }

}