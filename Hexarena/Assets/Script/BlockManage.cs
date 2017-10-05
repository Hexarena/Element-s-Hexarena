using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManage : MonoBehaviour {
	public GameObject block;
    private byte[,] Invalid;

    private static int width = 11;
    private static int height = 9;

    public static float yOffset = -0.735f;
    public static float xOffset = 1f;
    public static float col = -xOffset - xOffset / 2;

    void SetValid()
    {
        Invalid = new byte[9, 11]
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
    }
    Animator anim;
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
            SetValid();
            for (int jj = 0; jj < height; jj++)
            {
                if ((jj % 2 == 0) && (jj != 0))
                    col += xOffset;
                for (int ii = 0; ii < width; ii++)
                {
                    if (Invalid[jj, ii] == 0)
                    {
                        GameObject hex_go;
                        if (jj % 2 == 0)
                        {
                            hex_go = (GameObject)Instantiate(
                                block,
                                new Vector2(ii * xOffset - 5.5f + col, jj * yOffset - 7*yOffset / 2f),
                                Quaternion.identity);
                        }
                        else
                        {
                            hex_go = (GameObject)Instantiate(
                                block,
                                new Vector2(ii * xOffset + xOffset / 2 - 5.5f + col, jj * yOffset - 7*yOffset / 2f),
                                Quaternion.identity);
                        }

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
