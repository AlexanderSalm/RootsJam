using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    public static CursorController instance;

    public List<string> allPlaceable;

    public int placeableIndex = 0;

    public GardenItem currentlySelected;

    private Animator anim;

    public string tryingToSpawn = "";

    private bool initalized = false;

    private bool clickingUp = false;
    private bool clickingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Initalize();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clickingDown){
            clickingDown = false;
            placeableIndex--;
            if(placeableIndex == -1) placeableIndex = allPlaceable.Count - 1;
        }
        
        if(clickingUp){
            clickingUp = false;
            placeableIndex++;
            if(placeableIndex == allPlaceable.Count) placeableIndex = 0;
        }
    }

    public void Click(){
        Initalize();
        anim.SetTrigger("click");

        if(RaycastManager.instance.gardenItemSuccess){
            if(currentlySelected != null) currentlySelected.Deselect();
            currentlySelected = RaycastManager.instance.gardenItemHit.collider.gameObject.GetComponent<GardenItem>();
            currentlySelected.Select();
        }
        else if(RaycastManager.instance.groundRaycastSuccess){
            if(currentlySelected != null){
                currentlySelected.Deselect();
                currentlySelected = null;
            }
            else {
                if (currentlySelected != null) currentlySelected.Deselect();
                tryingToSpawn = allPlaceable[placeableIndex];
            }
        }
    }
    
    public void OnSwitchDecorUp(InputValue value){
        clickingUp = value.Get<float>() == 1.0f;
    }

    public void OnSwitchDecorDown(InputValue value){
        clickingDown = value.Get<float>() == 1.0f;
    }

    public CursorController Initalize(){
        if(!initalized){
            anim = GetComponent<Animator>();
        }

        initalized = true;
        return this;
    }
}
