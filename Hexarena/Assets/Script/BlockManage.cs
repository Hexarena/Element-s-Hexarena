using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManage : MonoBehaviour {
	public GameObject block;
	int row1=7, row2 = 8 ,row3 = 9, row4 = 10,row5 = 11;
	// Use this for initialization
	Animator anim;
	void Start () {
		//hand = GameObject.Find("1:1");
		//for (int i = 0; i < block.Length; i++)
		//{
		//	anim =block[i].GetComponent<Animator>();
		//	anim.SetInteger("Color", 4);
		//}
		if (block != null)
		{
			for (int i = 0; i < row1; i++)
			{
				GameObject a = GameObject.Instantiate(block, new Vector2(-3 + (1 * i), 3), Quaternion.Euler(0, 0, 90));
				a.name = "1:"+(i+1);
				a.transform.parent = gameObject.transform;
			}
			for (int i = 0; i < row2; i++)
			{
				GameObject a = GameObject.Instantiate(block, new Vector2(-3.5f + (1 * i), 2.25f), Quaternion.Euler(0, 0, 90));
				a.name = "2:" + (i + 1);
				a.transform.parent = gameObject.transform;
			}
			for (int i = 0; i < row3; i++)
			{
				GameObject a = GameObject.Instantiate(block, new Vector2(-4 + (1 * i), 1.5f), Quaternion.Euler(0, 0, 90));
				a.name = "3:" + (i + 1);
				a.transform.parent = gameObject.transform;
			}
			for (int i = 0; i < row4; i++)
			{
				GameObject a = GameObject.Instantiate(block, new Vector2(-4.5f + (1 * i), 0.75f), Quaternion.Euler(0, 0, 90));
				a.name = "4:" + (i + 1);
				a.transform.parent = gameObject.transform;
			}
			for (int i = 0; i < row5; i++)
			{
				GameObject a = GameObject.Instantiate(block, new Vector2(-5 + (1 * i), 0), Quaternion.Euler(0, 0, 90));
				a.name = "5:" + (i + 1);
				a.transform.parent = gameObject.transform;
			}
			for (int i = 0; i < row4; i++)
			{
				GameObject a = GameObject.Instantiate(block, new Vector2(-4.5f + (1 * i), -0.75f), Quaternion.Euler(0, 0, 90));
				a.name = "6:" + (i + 1);
				a.transform.parent = gameObject.transform;
			}
			for (int i = 0; i < row3; i++)
			{
				GameObject a = GameObject.Instantiate(block, new Vector2(-4 + (1 * i), -1.5f), Quaternion.Euler(0, 0, 90));
				a.name = "7:" + (i + 1);
				a.transform.parent = gameObject.transform;
			}
			for (int i = 0; i < row2; i++)
			{
				GameObject a = GameObject.Instantiate(block, new Vector2(-3.5f + (1 * i), -2.25f), Quaternion.Euler(0, 0, 90));
				a.name = "2:" + (i + 1);
				a.transform.parent = gameObject.transform;
			}
			for (int i = 0; i < row1; i++)
			{
				GameObject a = GameObject.Instantiate(block, new Vector2(-3 + (1 * i), -3), Quaternion.Euler(0, 0, 90));
				a.name = "1:" + (i + 1);
				a.transform.parent = gameObject.transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
