using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOj : MonoBehaviour
{
    Animator anim;
    GameObject obj;

    // del start nnvu Delete This_x, This_y
    // public byte This_x, This_y; //Position of this block
    // del end nnvu

    // del start nnvu Delete Manager
    //public BlockManage Manager; //The GameManage
    // del end
    public GameObject Figure;
    GameObject fig;
    // add start nnvu Add xOffSet for create Figure
    private static readonly float xOffSet = 1f;
    private static readonly float yOffSet = -0.735f;
    // add end nnvu
    // mod start nnvu Change Status type
    //private byte Status = 2; //this Block's status (1: Has Figure; 2: Empty)
    private BlockObjStatus Status = BlockObjStatus.CanMove; // blank Block
                                                            // mod end nnvu Change Status type

    //Run once the object is created
    void Start()
    {
        obj = gameObject;
        //Find the GameManage, the controller of the game
        // del start nnvu Delete Manager
        //Manager = GameObject.Find ("GameManage").GetComponent<BlockManage>();
        // del end nnvu
        anim = GetComponent<Animator>();
        anim = obj.GetComponent<Animator>();

        //Find the position of this block for further usage
        // del start nnvu Delete This_x, This_y
        //var FigureName = obj.name.Split('_');
        //This_x = (byte)(int)System.Double.Parse(FigureName[1]);
        //This_y = (byte)(int)System.Double.Parse(FigureName[2]);
        // del end nnvu
    }

    //Mouse Stay in the block	
    protected void OnMouseOver()
    {
        //Receive left-click
        if (Input.GetMouseButtonUp(0))
        {
            //Find this block's Invalid value from GameManage
            // del start nnvu Delete get block Valid from game manager
            //byte Invalid = Manager.getBlockValid(This_x,This_y);
            //Debug.Log ("Invalid VALUE = " + Invalid);
            // del end nnvu
            //Perform action according to Invalid value
            // del start nnvu remove Switch case
            //         switch (status){
            ////Summon Figure when value is 2
            //case : 
            //		Instantiate (Figure,
            //			GetPosition (),
            //			Quaternion.identity);
            //		status = 1;   //1: Has Figure
            //		break;
            //	//Otherwise
            //	default: //Do something
            //		break;
            //}
            // del end nnvu

            // add start nnvu Add figure Create
            if ((BlockObjStatus.HasFigure & Status) == 0 && BlockManage.isClick == 0)// t thêm 1 biến isCLick kiểm tra xem có đang chọn quân cờ nào ko
            {
                
                fig=(GameObject)Instantiate(
                    Figure,
                    GetPosition(),
                    Quaternion.identity);
                Status = Status | BlockObjStatus.HasFigure;
                fig.name = "figure";
                fig.transform.SetParent(this.transform);
                Debug.Log(Status);
            }
            else if ( Status.ToString() != "3" && BlockManage.isClick == 0)
            {

                BlockManage.isClick = 1;
                anim.SetInteger("Status", 2);

                Debug.Log("chon " + obj.name);
                BlockManage.priBlock = obj;
                BlockManage.priFigure = fig ;
            }
            else if ((Status.ToString() == "11" || Status.ToString() == "7" || Status == BlockObjStatus.HasFigure) && BlockManage.isClick == 1)
            {
                BlockManage.isClick = 0;
                returnColor();
                Debug.Log("khong the di chuyen " + obj.name);
            }
            else if ((Status.ToString() != "11" && Status.ToString() != "7" && Status.ToString() != "1") && BlockManage.isClick == 1)
            {
                BlockManage.priFigure.transform.position= GetPosition();
                if  (Status.ToString() == "3")
                {
                    Status = Status & BlockObjStatus.HasFigure;
                }
                else Status = Status | BlockObjStatus.HasFigure;
                Debug.Log("di chuyen " + obj.name);
                BlockManage.isClick = 0;
                returnColor();
           
            }
           
            // add end nnvu
        }
    }

    //Mouse Enter the block
    void OnMouseEnter()
    {
        if (BlockManage.isClick == 0)
        {
            anim.SetInteger("Status", 1);//Change this block status
            Debug.Log("Vo " + obj.name);
            Debug.Log(Status.ToString());
        }
    }
    //Mouse Exit the block
    void OnMouseExit()
    {
        if (BlockManage.isClick == 0)
        {

            anim.SetInteger("Status", 0);//Change this block status
            Debug.Log("Raa");
        }
    }

    // mod start nnvu Modify GetPosition
    //Vector2 GetPosition()
    //{
    //    float x = This_x * BlockManage.xOffset - 10.5f
    //                + BlockManage.xOffset * (This_y / 2f)
    //                + BlockManage.xOffset;

    //    float y = This_x * BlockManage.yOffset
    //                - 7 * BlockManage.yOffset / 2f;
    //    return new Vector2(x, y);
    //}
    // mod start nnvu Change Method GetPosition to public
    // Vector2 GetPosition()
    public Vector2 GetPosition()
    // mod end nnvu
    {
        var Name = obj.name.Split('_');
        var PosX = float.Parse(Name[1]);
        var PosY = float.Parse(Name[2]);
        float x = PosX * xOffSet - 7.5f
            + (PosY / 2) * xOffSet
            //+ (PosY % 2) * xOffSet / 2f
            + xOffSet / 2;

        float y = PosY * yOffSet
            + 2f
            - yOffSet * 1.5f;
        return new Vector2(x, y);
    }
    // mod end nnvu

    // add start nnvu set Status as create Block
    public void SetStatus(int status)
    {
        Status = (BlockObjStatus)((int)Status ^ status);
    }
    // add end nnvu
    void returnColor()
    {
        Animator Anim;
        Anim = BlockManage.priBlock.GetComponent<Animator>();
        Anim.SetInteger("Status", 0);
    }
}
