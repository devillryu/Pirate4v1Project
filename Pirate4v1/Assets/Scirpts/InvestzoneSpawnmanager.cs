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
    bool area1;
    bool area2;
    bool area3;
    bool area4;

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
        // TakeList = new List<int>(new int[item.Length]);
        for (int i = 0; i < item.Length && obj < 5; i++)
        {
            randomnumber = UnityEngine.Random.Range(1, (item.Length) + 1);
            if (area1 == false)
            {
                randomnumber = UnityEngine.Random.Range(1, (item.Length) - 7);
                area1 = true;
            }
            else if (area2 == false)
            {
                randomnumber = UnityEngine.Random.Range(4, (item.Length) - 4);
                area2 = true;
            }
            else if (area3 == false)
            {
                randomnumber = UnityEngine.Random.Range(7, (item.Length) - 1);
                area3 = true;
            }
            else if (area4 == false)
            {
                randomnumber = UnityEngine.Random.Range(10, (item.Length) + 1);
                area4 = true;
            }
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
