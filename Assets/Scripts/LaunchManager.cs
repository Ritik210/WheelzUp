using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject enterGamePanel;
    public GameObject connectionStatusPanel;
    public GameObject lobbyPanel;
    public string _newplayer1;
    public int arenaSelection = 0;


    #region Unity Methods

    private void Awake()
    {
        arenaSelection = 0;
        PhotonNetwork.AutomaticallySyncScene = true;

       // DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        enterGamePanel.SetActive(true);
        connectionStatusPanel.SetActive(false);
        lobbyPanel.SetActive(false);
    }

    #endregion

    #region Public Methods
    public void connectToPhotonServer()
    {
        if(!PhotonNetwork.IsConnected)
        {
           PhotonNetwork.ConnectUsingSettings();
            connectionStatusPanel.SetActive(true);
            enterGamePanel.SetActive(false);
        }
    }

    public void joinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void selectArena1()
    {
        arenaSelection = 0;
    }

    public void selectArena2()
    {
        arenaSelection = 1;
    }
    #endregion


    #region Photon callbacks
    // This function is called when we connected to photon servers.
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName + " is connected to network");
        lobbyPanel.SetActive(true);
        connectionStatusPanel.SetActive(false);
    }

    // This function is called when we are connected to internet.
    public override void OnConnected()
    {
        Debug.Log("Connected To internet");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        createAndJoinRoom();
        
    }

    public override void OnJoinedRoom()
    {
        //  base.OnJoinedRoom();
        Debug.Log(PhotonNetwork.NickName + " is Joined to " + PhotonNetwork.CurrentRoom.Name);

        if (arenaSelection == 0)
        {
            PhotonNetwork.LoadLevel("GameScene");
        }
        else if(arenaSelection == 1)
        {
            PhotonNetwork.LoadLevel("GameScene2");
        }
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log(newPlayer.NickName + " is Joined to " + PhotonNetwork.CurrentRoom.Name + " " + PhotonNetwork.CurrentRoom.PlayerCount);
       
    }
    #endregion

    #region Private Methods

    private void createAndJoinRoom()
    {
        string roomName = "Room " + Random.Range(0, 10000);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    #endregion

}
