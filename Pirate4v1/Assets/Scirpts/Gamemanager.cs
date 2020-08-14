using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Gamemanager : MonoBehaviourPun
{
    // public Player Playerprefab;
    // [HideInInspector]
    // public Player LocalPlayer;
    // Start is called before the first frame update
    public Transform[] SpawnPoint;
    void Awake()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }
        // else
        // print("connect");
        // print("awake");
    }
    void Start()
    {
        // Player.RefreshInstance(ref LocalPlayer, Playerprefab);
        //Foundbug
        CreatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Application.Quit();
        }
    }
    // public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    // {
    //     base.OnPlayerEnteredRoom(newPlayer);
    //     Player.RefreshInstance(ref LocalPlayer, Playerprefab);
    // }
   public void CreatePlayer()
    {

        List<int> list = new List<int>();

        for (int n = 0; n < SpawnPoint.Length; n++)    //  Populate list
        {
            list.Add(n);
        }
        print(list.Count);
        int spawnPicker = Random.Range(0, list.Count); //Bug
        
        if (Swaprole.chooserole.Role == "Survival")
            PhotonNetwork.Instantiate(Path.Combine("Photonprefabs", "Player"), SpawnPoint[spawnPicker].position, SpawnPoint[spawnPicker].rotation, 0);
        else
            PhotonNetwork.Instantiate(Path.Combine("Photonprefabs", "Hunter"), SpawnPoint[spawnPicker].position, SpawnPoint[spawnPicker].rotation, 0);
        list.RemoveAt(spawnPicker);
        print(spawnPicker);
    }

}
