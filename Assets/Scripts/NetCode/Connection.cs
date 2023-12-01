using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Connection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("conectado al master");
    }

    public void ButtonConnect()
    {
        RoomOptions options = new RoomOptions() { MaxPlayers = 4};

        PhotonNetwork.JoinOrCreateRoom("room1", options, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("conectada a la sala " + PhotonNetwork.CurrentRoom.Name);
    }


}
