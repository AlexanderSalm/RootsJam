using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    public string objectFind;
    public Vector3 mask;

    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        if (objectFind != "") target = GameObject.Find(objectFind);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null){
            Vector3 diff = target.transform.position - transform.position;
            diff.Scale(-1.0f * mask);
            transform.rotation = Quaternion.LookRotation(diff);
        }
    }

    public void SetTarget(GameObject target){
        this.target = target;
    }
}
