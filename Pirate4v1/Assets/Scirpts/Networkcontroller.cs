 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Networkcontroller : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        Debug.Log("connect to" + PhotonNetwork.CloudRegion + "server");
    }
}
