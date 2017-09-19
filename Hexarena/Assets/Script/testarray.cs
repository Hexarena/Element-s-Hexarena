using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testarray : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string a = "1:2:3:4";
		string[] b = a.Split(':');
		Debug.Log(b[1]);
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
