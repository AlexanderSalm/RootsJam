using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSettings : MonoBehaviour
{
    private bool played = false;
    public void Play(){
        GetComponent<AudioSource>().Play();
        played = true;
    }

    void Update(){
        if (!GetComponent<AudioSource>().isPlaying && played){
            Destroy(gameObject);
        }
    }
}
