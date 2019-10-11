using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Photon.PunBehaviour {

    //Version number of this client. Photon will seperate the users by version number,
    //so by changing this you can basically have a private beta version of the game
    public string _gameVersion = "1";

    public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;

    public byte MaxPlayersPerRoom = 8;

    public GameObject progressText;

    public GameObject gameLobbyPanel;

    void Awake()
    {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.logLevel = Loglevel;
    }
    public void Connect()
    {
        progressText.SetActive(true);
        if(PhotonNetwork.connected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings(_gameVersion);
        }
    }
    public override void OnConnectedToMaster()
    {
        progressText.SetActive(false);
        gameLobbyPanel.SetActive(true);

        Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }
    public override void OnDisconnectedFromPhoton()
    {
        Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");
    }
}
