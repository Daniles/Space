﻿using UnityEngine;
using System.Collections;

public class BarrierHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D colliderEnter)
    {
        Destroy(colliderEnter.gameObject);
    }
}
