﻿using UnityEngine;
using System.Collections;

public class Teste : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(GameObject.FindGameObjectsWithTag("Inimigo"));
	
	}
}
