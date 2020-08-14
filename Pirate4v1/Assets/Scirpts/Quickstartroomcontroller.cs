using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Quickstartroomcontroller : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiplayerSceneIndex;
    // Start is called before the first frame update
    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    public override void OnJoinedRoom()
    {
        StartGame();
    }
    void StartGame()
    {
        
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
            // photonView.RPC("RPC_CreatePlayer",RpcTarget.All);
        }
    }
    // [PunRPC]
    // void RPC_CreatePlayer()
    // {
    //     PhotonNetwork.Instantiate(Path.Combine("Photonprefabs", "Player"), transform.position, Quaternion.identity, 0);
    // }
}
