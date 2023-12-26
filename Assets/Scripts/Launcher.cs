using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{ 
  
    [SerializeField] private byte maxPlayersPerRoom = 2;
    public bool isConnecting;
    public float speed = 5;
   

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
    }

    //Connect & Disconnect Master
    public override void OnConnectedToMaster()
    {
        isConnecting = true;
        Debug.Log("<color=#FFFF00>Connected to photon!</color>");
        if(isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
           
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        isConnecting = false;
        Debug.LogWarningFormat(" OnDisconnected", cause);
    }

    //Joined Room

    public override void OnJoinedRoom()
    {
      
        Debug.Log($"{PhotonNetwork.CurrentRoom.Name} Joined!");
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
       
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Debug.Log("We load the 'RoomFor1' ");
            PhotonNetwork.LoadLevel("RoomFor1");
               
        }
       
      
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        Debug.Log(" PhotonNetwork.CreateRoom");
        
    }

    //Left Room
    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"{otherPlayer.NickName} has Left the Room");

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("2 Player join");
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.LoadLevel("RoomFor1");
            Debug.Log("We load the 'RoomFor1' ");
        }
       

    }
    
}


