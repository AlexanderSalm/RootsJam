using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordinatesController : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set color
        text.color = new Color(text.color.r, text.color.g, text.color.b, CameraController.instance.GetTravelingSpeed());

        //Set text content
        text.text = ((int)(CameraController.instance.transform.position.x)).ToString() + ", " + ((int)(CameraController.instance.transform.position.z)).ToString();
    }
}
