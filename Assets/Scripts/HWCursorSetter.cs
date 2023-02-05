using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HWCursorSetter : MonoBehaviour
{
    public bool visible;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = visible;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
