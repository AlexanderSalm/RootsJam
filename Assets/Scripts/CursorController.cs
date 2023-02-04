using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static CursorController instance;

    public GameObject currentPlaceable;

    private GardenItem currentlySelected;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(){
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
                GameObject g = Instantiate(currentPlaceable);
                g.transform.position = RaycastManager.instance.groundHit.point;
                if (currentlySelected != null) currentlySelected.Deselect();
                g.GetComponent<GardenItem>().Initalize().Select();
                currentlySelected = g.GetComponent<GardenItem>();
            }
        }
    }
}
