using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class InvestzoneSpawnmanager : MonoBehaviourPun
{
    [SerializeField] Transform[] item;
    [SerializeField] GameObject objective;
    public List<int> TakeList = new List<int>();
    private int randomnumber;
    int obj;

    void Start()
    {
        // photonView.RPC("Spawnzone", RpcTarget.AllBuffered);
        if (PhotonNetwork.IsMasterClient)
        {
            Spawnzone();
        }
    }
    void Spawnzone()
    {
        TakeList = new List<int>(new int[item.Length]);
        for (int i = 0; i < item.Length && obj < 3; i++)
        {
            randomnumber = UnityEngine.Random.Range(1, (item.Length) + 1);
            while (TakeList.Contains(randomnumber))
            {
                randomnumber = UnityEngine.Random.Range(1, (item.Length) + 1);
            }
            TakeList[i] = randomnumber;
            PhotonNetwork.Instantiate(Path.Combine("Photonprefabs", objective.name), item[TakeList[i] - 1].position, Quaternion.identity);
            obj++;
        }
    }
}
