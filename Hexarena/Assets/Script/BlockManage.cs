using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManage : MonoBehaviour {
	public GameObject block;
    // mod start nnvu Change Invalid to static const
    //private byte[,] Invalid
    private static readonly byte[,] Invalid =
    {
        { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
        { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 },
    };
    // mod end nnvu

    // mod start nnvu Change type of size
    private static readonly int width = 11;
    private static readonly int height = 9;
    //private static int width = 11;
    //private static int height = 9;
    // mod end nnvu

    // mod start nnvu change yOffset, col, xOffset to static const
    //public static float yOffset = -0.735f;
    //public static float xOffset = 1f;
    //public static float col = -xOffset - xOffset / 2;
    private static readonly float yOffset = -0.735f;
    private readonly static float xOffset = 1f;
    private static float col = -xOffset - xOffset / 2;
    // mod end nnvu

    // del start nnvu remove SetInvalid
    //void SetValid()
    //{
    //    Invalid = new byte[9, 11]
    //    {
    //        { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
    //        { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    //        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    //        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    //        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
    //        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 },
    //        { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 },
    //    };
    //}
    // del end nnvu remove SetInvalid

    //Return the Invalid value of a block [x,y]
    public byte getBlockValid(byte Pos_x, byte Pos_y){
		return Invalid[Pos_x,Pos_y];
	}
    // del start nnvu Delete amin
    //Animator anim;
    // del end nnvu
    void Start()
    {
        //hand = GameObject.Find("1:1");
        //for (int i = 0; i < block.Length; i++)
        //{
        //	anim =block[i].GetComponent<Animator>();
        //	anim.SetInteger("Color", 4);
        //}
        if (block != null)
        {
            // del start nnvu remove SetInvalid
            //SetValid();
            // del end nnvu remve SetInvalid
            for (int jj = 0; jj < height; jj++)
            {
                if ((jj % 2 == 0) && (jj != 0))
                    col += xOffset;
                for (int ii = 0; ii < width; ii++)
                {
                    if (Invalid[jj, ii] == 0)
                    {
                        GameObject hex_go;
                        // mod start nnvu Change How to create Base
                        //if (jj % 2 == 0)
                        //{
                        //    hex_go = (GameObject)Instantiate(
                        //        block,
                        //        new Vector2(ii * xOffset - 5.5f + col, jj * yOffset - 7*yOffset / 2f),
                        //        Quaternion.identity);
                        //}
                        //else
                        //{
                        //    hex_go = (GameObject)Instantiate(
                        //        block,
                        //        new Vector2(ii * xOffset + xOffset / 2 - 5.5f + col, jj * yOffset - 7*yOffset / 2f),
                        //        Quaternion.identity);
                        //}
                        hex_go = (GameObject)Instantiate(
                            block,
                            new Vector2(
                                ii *xOffset - 5.5f + col + (jj % 2) * xOffset / 2f,
                                jj * yOffset + 3f),
                            Quaternion.identity);
                        // mod end nnvu
                        hex_go.name = "Base_" + ii + "_" + jj;
                        hex_go.transform.SetParent(this.transform);
                    }
                }
            }
        }
    }

        // Update is called once per frame
        void Update () {
		
	    }
}
