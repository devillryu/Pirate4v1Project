using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class Box : MonoBehaviourPun
{    public static bool isOpen = false;

    public void Update()
    {
        photonView.RPC("OpenChest", RpcTarget.All);
    }

    [PunRPC]
    public void OpenChest()
    {
        if (isOpen == true)
        {
            PhotonNetwork.Destroy(this.gameObject);
            PhotonNetwork.Instantiate(Path.Combine("Photonprefabs", "OpenChest"), this.transform.position, Quaternion.identity); //Fix position
        }
        else
        {

        }
    }


}
