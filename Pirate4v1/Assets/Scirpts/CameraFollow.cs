﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraFollow : MonoBehaviourPun
{
	void Start()
	{
		if(!photonView.IsMine)
            {
                Destroy(this.gameObject);
            }
	}
    // public Transform target;

	// public float smoothSpeed = 0.125f;
	// public Vector3 offset;
    // void Start()
    // {
		
    // }

	// void FixedUpdate()
	// {
	// 	Vector3 desiredPosition = target.position + offset;
	// 	Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
	// 	transform.position = smoothedPosition;

	// 	transform.LookAt(target);
	// }
}
