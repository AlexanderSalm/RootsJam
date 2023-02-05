using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed;
    public Vector3 mask;

    private Vector3 rot;

    void Start(){
        rot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        rot += (mask * speed * Time.deltaTime);
        transform.eulerAngles = rot;
    }
}
