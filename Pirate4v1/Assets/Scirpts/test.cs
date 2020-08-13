using System.Collections;
 using System.Collections.Generic;
 using Photon.Pun;
 using UnityEngine;
 public class test : MonoBehaviourPun
 {
 
  public GameObject cube;
  void Start()
  {
      
  }
  void Update()
  {
          if (Input.GetKeyDown(KeyCode.E))
          {
             float r = Random.Range(0f, 1f);
             float g = Random.Range(0f, 1f);
             float b = Random.Range(0f, 1f);
 
              print(r + " " + g + " " + b);
              photonView.RPC("changeColour", RpcTarget.AllBuffered, r,g,b);
          }
  }
 
  [PunRPC] 
  void changeColour(float r, float g, float b)
  {
      cube.GetComponent<Renderer>().material.color = new Color(r, g, b, 1f);
  }
 }