using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOj : MonoBehaviour
{
    Animator anim;
    GameObject obj;
	GameObject fig;
    public static GameObject priBlock;
    public static GameObject priFigure;
    // del start nnvu Delete This_x, This_y
    // public byte This_x, This_y; //Position of this block
    // del end nnvu

    // del start nnvu Delete Manager
    //public BlockManage Manager; //The GameManage
    // del end

    public GameObject Figure;
    // add start nnvu Add xOffSet for create Figure
    private static readonly float xOffSet = 1f;
    private static readonly float yOffSet = -0.735f;
    // add end nnvu
    // mod start nnvu Change Status type
    //private byte Status = 2; //this Block's status (1: Has Figure; 2: Empty)
    private BlockObjStatus Status = BlockObjStatus.CanMove; // blank Block
                                                            // mod end nnvu Change Status type
    public BlockObjStatus status{ get; set; }

	private int[] AffectedBlocks = new int[200]; //Tọa độ những ô bị thay đổi màu (lưu kiểu X * 100 + Y)
	public int countAffectedBlocks = 0;
	//Run once the object is created
    void Start()
    {
        obj = gameObject;
        //Find the GameManage, the controller of the game
        // del start nnvu Delete Manager
        //Manager = GameObject.Find ("GameManage").GetComponent<BlockManage>();
        // del end nnvu
        //anim = GetComponent<Animator>();
        anim = obj.GetComponent<Animator>();

        //Find the position of this block for further usage
        // del start nnvu Delete This_x, This_y
        //var FigureName = obj.name.Split('_');
        //This_x = (byte)(int)System.Double.Parse(FigureName[1]);
        //This_y = (byte)(int)System.Double.Parse(FigureName[2]);
        // del end nnvu
    }

    //void OnMouseDown()
    //{
    //    if ((BlockObjStatus.HasFigure & Status) == 0)
    //    {
    //        Instantiate(
    //            Figure,
    //            GetPosition(),
    //            Quaternion.identity);
    //        Status = Status | BlockObjStatus.HasFigure;
    //    }
    //}
    /* Should use OnMouseDown (above) instead? - PrInc3 */

    //Mouse Stay in the block	
    private void OnMouseOver()
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
			if ((BlockObjStatus.HasFigure & Status) == 0 && BlockManage.isClick == 0)
              {
				fig = (GameObject) Instantiate(
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

				//Tìm tọa độ các ô cần thay màu
				string[] Name = obj.name.Split('_');
				SetAffectedBlocks(int.Parse(Name[1]),int.Parse(Name[2]), 3); //Giá trị truyền vào sau là bán kính
				Debug.Log ("So O: " + countAffectedBlocks);
				//Đổi màu các ô đã chọn
				ChangeColor(AffectedBlocks,2);

                 Debug.Log("chon " + obj.name);
                 priBlock = obj;
                 priFigure = fig ;
             }
             else if ((Status.ToString() == "11" || Status.ToString() == "7" || Status == BlockObjStatus.HasFigure) && BlockManage.isClick == 1)
             {
                 BlockManage.isClick = 0;
                 returnColor();
				 anim.SetInteger ("Status", 1);

				//Chỉnh lại màu cho các ô màu đỏ trước đó
				BlockOj tmpBlkObj = priBlock.GetComponent<BlockOj> ();
				tmpBlkObj.ChangeColor (tmpBlkObj.AffectedBlocks,0);

                 Debug.Log("khong the di chuyen " + obj.name);
             }
             else if ((Status.ToString() != "11" && Status.ToString() != "7" && Status.ToString() != "1") && BlockManage.isClick == 1)
			{
				//Kiểm tra xem có thể di chuyển Figure ơơơđến ô đã chơọn khơông
				BlockOj tmpBlkObj = priBlock.GetComponent<BlockOj> ();
				bool CanMove = false;
				string[] Name = obj.name.Split('_');
				for (int i = 0; i < tmpBlkObj.countAffectedBlocks; i++) {
					if (tmpBlkObj.AffectedBlocks[i] == (int.Parse(Name[1])*100+int.Parse(Name[2]))) {
						CanMove = true;
					}
				}
				if (!(CanMove)) {
					Debug.Log ("Qua gioi han di chuyen");
					return;
				}

                returnColor();
                priFigure.transform.position = GetPosition();
                fig = priFigure;        
                priFigure = null;
                BlockOj hexScript = (BlockOj) priBlock.GetComponent(typeof(BlockOj)); //set lại status cho prj chọn trước đó,
                hexScript.SetStatusMove(1);    
                if  (Status.ToString() == "3") // trường hợp những ô không nằm trong vùng triệu hồi quân, 
                    //có giá trị là 3, thì khi dùng lệnh Status = Status | BlockObjStatus.HasFigure sẽ vẫn có giá trị là 3
                    //nên ta đổi sang phép tính khác để trả về 1 giá trị khác là 1
                 {
                     Status = Status & BlockObjStatus.HasFigure;
                 }
				else Status = Status | BlockObjStatus.HasFigure;

				//Chỉnh lại màu cho các ô màu đỏ trước đó
				tmpBlkObj.ChangeColor (tmpBlkObj.AffectedBlocks,0);

                Debug.Log("di chuyen " + obj.name);
                BlockManage.isClick = 0;
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
		if (BlockManage.isClick == 0) {
			anim.SetInteger ("Status", 0);//Change this block status
			Debug.Log ("Raa");
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
        return new Vector2(x, y + 0.6f);
    }
    // mod end nnvu

    // add start nnvu set Status as create Block
    public void SetStatus(int status)
    {
        Status = (BlockObjStatus)((int)Status | status);
    }
    public void SetStatusMove(int status)   //hàm set Status không trùng với hàm dùng trong BlockManage
    {
        if(Status==BlockObjStatus.HasFigure)    // khi prj nằm ở vị trí không thể triệu hồi được quân cờ,
        {
            status = 3;                         
            Status = (BlockObjStatus)((int)Status | status);
            // khi dùng lệnh Status = (BlockObjStatus)((int)Status ^ status); thì Status=0, làm prj có thể triệu hồi quân cờ được
            //nhưng prj đó nằm ở vị trí không thể triệu hồi cờ, nên statu=3, đổi phép tính sang | để Status=3, tức là không thể triệu hồi cờ
        }
        else Status = (BlockObjStatus)((int)Status ^ status);
    }
    // add end nnvu

	void returnColor()
	{
	        Animator Anim;
	        Anim = priBlock.GetComponent<Animator>();
	        Anim.SetInteger("Status", 0);
	}

	void SetAffectedBlocks(int X, int Y, int Radius) {
		if (Radius == 0){
			int tmpInt = X * 100 + Y;
			//Check if the Block is already in the array
			for (int i = 0; i < countAffectedBlocks; i++) {
				if (AffectedBlocks[i] == tmpInt) {
					return;
				}
			}
			AffectedBlocks[countAffectedBlocks] = tmpInt;
			countAffectedBlocks++;
		}
		else{
			for (int i = -1; i <= 1; i++) {
				for (int j = 0; j <= 1; j++) {
					SetAffectedBlocks(X - j * i, Y + i, Radius-1);
				}
			}	
			SetAffectedBlocks(X - 1, Y, Radius-1);
			SetAffectedBlocks(X + 1, Y, Radius-1);
		}
	}
	//Đổi màu các ô có tọa độ (kiểu X*10+Y) lưu trong mảng Blocks thành StatusValue
	void ChangeColor(int[] Blocks, int StatusValue){
		Debug.Log ("-- Changing --- " + gameObject.name);
		//Debug.Log ("Doi mau sang "+StatusValue+": "+(AffectedBlocks[0])+" "+(AffectedBlocks[1])+" "+(AffectedBlocks[2])+
		//	" "+(AffectedBlocks[3])+" "+(AffectedBlocks[4])+" "+(AffectedBlocks[5]));
		for (int i = 0; i < countAffectedBlocks; i++) {
			Debug.Log (Blocks [i] / 100 + " " + Blocks [i] % 100);
			string BlkName = "Base_" + Blocks[i]/100 + "_" + Blocks[i]%100;
			Animator TmpAnim = null;
			try {
				TmpAnim = GameObject.Find (BlkName).GetComponent<Animator> ();
				TmpAnim.SetInteger ("Status", StatusValue);
			}
			catch{
			}
		}
	}
}
