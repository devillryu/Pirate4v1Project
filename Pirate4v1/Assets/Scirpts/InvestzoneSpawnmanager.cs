using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class InvestzoneSpawnmanager : MonoBehaviourPun
{
    [SerializeField] Transform[] item;
    [SerializeField] Transform[] itembox;
    [SerializeField] Transform[] cage;
    [SerializeField] GameObject objective;
    [SerializeField] GameObject Itembox;
    [SerializeField] GameObject cageobject;
    public List<int> TakeList = new List<int>();
    public List<int> TakeList2 = new List<int>();
    public List<int> TakeList3 = new List<int>();
    private int randomnumber;
    private int randomnumberbox;
    private int randomnumbercage;
    int itemboxobj;
    int obj;
    int cageobj;
    bool area1, area2, area3, area4;
    bool area1b, area2b, area3b, area4b;
    bool area1c, area2c, area3c, area4c;

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
                randomnumber = UnityEngine.Random.Range(1, (item.Length) - 9);
                area1 = true;
            }
            else if (area2 == false)
            {
                randomnumber = UnityEngine.Random.Range(4, (item.Length) - 6);
                area2 = true;
            }
            else if (area3 == false)
            {
                randomnumber = UnityEngine.Random.Range(7, (item.Length) - 3);
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


        //BOX SPAWN

        for (int j = 0; j < itembox.Length && itemboxobj < 6; j++)
        {
            if (area1b == false)
            {
                int a = 0;
                if (a < 1)
                {
                    randomnumberbox = UnityEngine.Random.Range(1, (itembox.Length) - 12);
                    a++;
                }
                randomnumberbox = UnityEngine.Random.Range(1, (itembox.Length) - 12);
                area1b = true;
            }
            else if (area2b == false)
            {
                randomnumberbox = UnityEngine.Random.Range(5, (itembox.Length) - 8);
                area2b = true;
            }
            else if (area3b == false)
            {
                randomnumberbox = UnityEngine.Random.Range(9, (itembox.Length) - 4);
                area3b = true;
            }
            else if (area4b == false)
            {
                int d = 0;
                if (d < 1)
                {
                    randomnumberbox = UnityEngine.Random.Range(13, (itembox.Length));
                    d++;
                }
                randomnumberbox = UnityEngine.Random.Range(13, (itembox.Length));
                area4b = true;
            }
            while (TakeList2.Contains(randomnumberbox))
            {
                randomnumberbox = UnityEngine.Random.Range(1, (itembox.Length) + 1);
            }
            TakeList2[j] = randomnumberbox;
            PhotonNetwork.Instantiate(Path.Combine("Photonprefabs", Itembox.name), itembox[TakeList2[j] - 1].position, Quaternion.identity);
            itemboxobj++;
        }
        //Spawncage
        for (int k = 0; k < cage.Length && cageobj < 8; k++)
        {
            if (area1c == false)
            {
                int a = 0;
                if (a < 1)
                {
                    randomnumberbox = UnityEngine.Random.Range(1, (cage.Length) - 9);
                    a++;
                }
                randomnumberbox = UnityEngine.Random.Range(1, (cage.Length) - 9);
                area1b = true;
            }
            else if (area2c == false)
            {
                int b = 0;
                if (b < 1)
                {
                    randomnumberbox = UnityEngine.Random.Range(4, (cage.Length) - 6);
                    b++;
                }
                randomnumberbox = UnityEngine.Random.Range(4, (cage.Length) - 6);
                area2b = true;
            }
            else if (area3c == false)
            {
                int c = 0;
                if (c < 1)
                {
                    randomnumberbox = UnityEngine.Random.Range(7, (cage.Length) - 3);
                    c++;
                }
                randomnumberbox = UnityEngine.Random.Range(7, (cage.Length) - 3);
                area3b = true;
            }
            else if (area4c == false)
            {
                int d = 0;
                if (d < 1)
                {
                    randomnumberbox = UnityEngine.Random.Range(10, (cage.Length) + 1);
                    d++;
                }
                randomnumberbox = UnityEngine.Random.Range(10, (cage.Length) + 1);
                area4c = true;
            }
            while (TakeList3.Contains(randomnumberbox))
            {
                randomnumberbox = UnityEngine.Random.Range(1, (cage.Length) + 1);
            }
            TakeList3[k] = randomnumberbox;
            PhotonNetwork.Instantiate(Path.Combine("Photonprefabs", cageobject.name), cage[TakeList3[k] - 1].position, Quaternion.identity);
            cageobj++;
        }
    }
}
