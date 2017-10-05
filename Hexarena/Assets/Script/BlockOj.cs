using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOj : MonoBehaviour {
	Animator anim;
	GameObject obj;
    public GameObject goFigure;
    bool isHasFigure = false;
	// Use this for initialization
	void Start () {
		obj = gameObject;
		anim = GetComponent<Animator>();
		anim = obj.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        if (!isHasFigure)
        {
            isHasFigure = true;
            Instantiate(goFigure,
                getPosition(obj.name),
                Quaternion.identity)
                .transform.SetParent(this.transform);
        }
    }

    void OnMouseEnter()
	{
		anim.SetInteger("Status", 1);
		Debug.Log("Vo "+obj.name);
	}

	void OnMouseExit()
	{
		anim.SetInteger("Status", 0);
		Debug.Log("Raa");
	}

    Vector2 getPosition(string name)
    {
        var FigureName = name.Split('_');
        float x = (float)System.Double.Parse(FigureName[1]);
        float y = (float)System.Double.Parse(FigureName[2]);
        x = x * BlockManage.xOffset - 10.5f +
            BlockManage.xOffset * (y / 2f) +
            BlockManage.xOffset;
        y = y * BlockManage.yOffset -
            7 * BlockManage.yOffset / 2f;
        return new Vector2(x, y);
    }
}
