using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOj : MonoBehaviour {
	Animator anim;
	GameObject obj;
	// Use this for initialization
	void Start () {
		obj = gameObject;
		anim = GetComponent<Animator>();
		anim = obj.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseEnter()
	{
		anim.SetInteger("Status", 1);
		Debug.Log("Voo");
	}

	void OnMouseExit()
	{
		anim.SetInteger("Status", 0);
		Debug.Log("Raa");
	}
}
