﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class NetworkConnectionManager : MonoBehaviourPunCallbacks
{
    public Button BtnConnectMaster;
    public Button BtnConnectRoom;
    public bool TriesToConnectToMaster;
    public bool TriesToConnectToRoom;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        TriesToConnectToMaster = false;
        TriesToConnectToRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BtnConnectMaster != null)
            BtnConnectMaster.gameObject.SetActive(!PhotonNetwork.IsConnected && !TriesToConnectToMaster);
        if (BtnConnectRoom != null)
            BtnConnectRoom.gameObject.SetActive(PhotonNetwork.IsConnected && !TriesToConnectToMaster && !TriesToConnectToRoom);
    }
    public void OnClickConnectToMaster()
    {
        PhotonNetwork.OfflineMode = false;
        PhotonNetwork.NickName = "Playername";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "v1";
        TriesToConnectToMaster = true;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        TriesToConnectToMaster = false;
        Debug.Log("Connect to master");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        TriesToConnectToMaster = false;
        TriesToConnectToRoom = false;
        Debug.Log(cause);
    }

    public void OnClickConnectToRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        TriesToConnectToRoom = true;
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        TriesToConnectToRoom = false;
        Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players In Room: " + PhotonNetwork.CurrentRoom.PlayerCount);
        SceneManager.LoadScene("SampleScene");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 5 });
    }
    // public override void OnCreateRoomFailed(short returnCode, string message)
    // {
    //     base.OnCreateRoomFailed(returnCode, message);
    //     Debug.Log(message);
    //     TriesToConnectToRoom = false;
    // }
    // public override void OnCreatedRoom()
    // {
    //     base.OnCreatedRoom();
    // }
}
