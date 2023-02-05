using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript : NetworkBehaviour
{
    public static PlayerScript instance;
    void Start(){
        instance = this;
    }

    void Update(){
        if(CursorController.instance.tryingToSpawn != ""){
            CmdSpawnItem(CursorController.instance.tryingToSpawn, RaycastManager.instance.groundHit.point);
            CursorController.instance.tryingToSpawn = "";
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdSpawnItem(string target, Vector3 point){
        Debug.Log(CursorController.instance.tryingToSpawn);
        GameObject prefab = Resources.Load<GameObject>(target);
        Debug.Log(prefab);
        GameObject g = Instantiate(prefab);
        g.transform.position = point;
        g.GetComponent<GardenItem>().Initalize().Select();

        NetworkServer.Spawn(g);
    }
}
