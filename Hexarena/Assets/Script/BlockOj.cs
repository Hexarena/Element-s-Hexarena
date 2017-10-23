using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOj : MonoBehaviour {
	Animator anim;
	GameObject obj;
	public byte This_x, This_y; //Position of this block
	public BlockManage Manager; //The GameManage
    public GameObject goFigure;
	//bool isHasFigure = false;

	//Run once the object is created
	void Start () {
		obj = gameObject;
		//Find the GameManage, the controller of the game
		Manager = GameObject.Find ("GameManage").GetComponent<BlockManage>();
		anim = GetComponent<Animator>();
		anim = obj.GetComponent<Animator>();

		//Find the position of this block for further usage
		var FigureName = obj.name.Split('_');
		This_x = (byte)(int)System.Double.Parse(FigureName[1]);
		This_y = (byte)(int)System.Double.Parse(FigureName[2]);
	}

	//Mouse Stay in the block	
    private void OnMouseOver()
    {
		//Receive left-click
		if (Input.GetMouseButtonUp (0)) {
			//Find this block's Invalid value from GameManage
			byte Invalid = Manager.getBlockValid(This_x,This_y);
			Debug.Log ("Invalid VALUE = " + Invalid);
			//Perform action according to Invalid value
			switch(Invalid){
			case 2: 
				//Summon Figure when value is 2
					Instantiate (goFigure,
						getPosition (),
						Quaternion.identity)
						.transform.SetParent (this.transform);
					break;
				//Otherwise
				default: //Do something
					break;
			}
		}
    }

	//Mouse Enter the block
    void OnMouseEnter()
	{
		anim.SetInteger("Status", 1);//Change this block status
		Debug.Log("Vo "+obj.name);
	}
	//Mouse Exit the block
	void OnMouseExit()
	{
		anim.SetInteger("Status", 0);//Change this block status
		Debug.Log("Raa");
	}

	Vector2 getPosition()
	{
		float x = This_x * BlockManage.xOffset - 10.5f 
					+ BlockManage.xOffset * (This_y / 2f) 
					+ BlockManage.xOffset;
		
		float y = This_x * BlockManage.yOffset
					- 7 * BlockManage.yOffset / 2f;
		return new Vector2(x, y);
	}
}
