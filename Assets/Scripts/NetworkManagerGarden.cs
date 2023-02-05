using UnityEngine;
using Mirror;

/*
	Documentation: https://mirror-networking.gitbook.io/docs/components/network-manager
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkManager.html
*/

[AddComponentMenu("")]
public class NetworkManagerGarden : NetworkManager
{

    public static NetworkManagerGarden instance;

    public override void Start(){
        base.Start();
        instance = this;
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // add player at correct spawn position
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);

        // spawn ball if two players
        /*if (numPlayers == 2)
        {
            ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
            NetworkServer.Spawn(ball);
        }*/
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        // destroy ball
        /*if (ball != null)
            NetworkServer.Destroy(ball);*/

        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}

