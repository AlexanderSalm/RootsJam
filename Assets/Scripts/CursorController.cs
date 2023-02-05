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
    public GameObject tryingToDelete;

    private bool initalized = false;

    private bool clickingUp = false;
    private bool clickingDown = false;
    private bool clickingDelete = false;

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

            SelectedInformationController.instance.RefreshSelected(allPlaceable[placeableIndex]);
        }
        
        if(clickingUp){
            clickingUp = false;
            placeableIndex++;
            if(placeableIndex == allPlaceable.Count) placeableIndex = 0;

            SelectedInformationController.instance.RefreshSelected(allPlaceable[placeableIndex]);
        }

        if(clickingDelete){
            clickingDelete = false;
            Delete();
        }
    }

    public void Click(){
        Initalize();
        anim.SetTrigger("click");

        if(RaycastManager.instance.gardenItemSuccess){
            if(currentlySelected != null) currentlySelected.Deselect();
            currentlySelected = RaycastManager.instance.gardenItemHit.collider.gameObject.transform.parent.gameObject.GetComponent<GardenItem>();
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

    public void Delete(){
        Initalize();
        if(currentlySelected == null) return;
        tryingToDelete = currentlySelected.gameObject;

    }
    
    public void OnSwitchDecorUp(InputValue value){
        clickingUp = value.Get<float>() == 1.0f;
    }

    public void OnSwitchDecorDown(InputValue value){
        clickingDown = value.Get<float>() == 1.0f;
    }

    public void OnDelete(InputValue value){
        clickingDelete = value.Get<float>() == 1.0f;
        Debug.Log("delete clicked");
    }

    public CursorController Initalize(){
        if(!initalized){
            anim = GetComponent<Animator>();

            SelectedInformationController.instance.RefreshSelected(allPlaceable[placeableIndex]);
        }

        initalized = true;
        return this;
    }
}
