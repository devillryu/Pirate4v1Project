using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Quickstartlobbycontroller : MonoBehaviourPunCallbacks
{
    public GameObject quickstartbutton;
    public GameObject quickcancelbutton;
    public int Roomsize;
    private ExitGames.Client.Photon.Hashtable _mycustomProperties = new ExitGames.Client.Photon.Hashtable();
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickstartbutton.SetActive(true);
    }
    public void QuickStart()
    {
        quickstartbutton.SetActive(false);
        quickcancelbutton.SetActive(true);
        // if (Swaprole.chooserole.Role == "Survival")      //ใช้ได้ห้องเดียว
        // {
        //     if (PhotonNetwork.SurCount <= 3)
        //     {
        //         PhotonNetwork.SurCount++;
        //         PhotonNetwork.JoinRandomRoom();
        //     }
        //     else
        //     {
        //         CreateRoom();
        //     }
        // }
        // else
        // {
        //     if (PhotonNetwork.HaveHunter == false)
        //     {
        //         PhotonNetwork.HaveHunter = !PhotonNetwork.HaveHunter;
        //         PhotonNetwork.JoinRandomRoom();
                
        //     }
        //     else
        //     {
        //         CreateRoom();
        //     }
        // }
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Quick start");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join");
        CreateRoom();
    }
    void CreateRoom()
    {
        Debug.Log("Create Room");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = (byte)Roomsize};
        // roomOps.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();
        // int Surcount = (int)roomOps.Currentroom.CustomRoomProperties["Surcount"];
        // _mycustomProperties["SurvivalCount"] =0;
        // PhotonNetwork.LocalPlayer.CustomProperties = _mycustomProperties;

        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }
    public void QuickCancel()
    {
        quickcancelbutton.SetActive(false);
        quickstartbutton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    
}
