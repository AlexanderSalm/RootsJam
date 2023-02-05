using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenItem : MonoBehaviour
{
    public string itemName;
    private Outline outline;

    private bool initalized;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        Initalize();
    }

    public void Select(){
        outline.enabled = true;
    }

    public void Deselect(){
        outline.enabled = false;
    }

    public GardenItem Initalize(){
        if(!initalized){
            outline = GetComponent<Outline>();

            initalized = true;
        }

        return this;
    }

    void OnDestroy(){

    }
}
