/*This file contains all "manager script" (Draw, Card, Block) - PrInc3 
 Each manager has 3 parts: 
  + Variables 
  + Events
  + Properties (public variables (maybe) with get set method)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    #region Block Manager

    #region Variables 
    private static readonly byte[,] Invalid =
   {
        { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1},
        { 0, 0, 0, 4, 4, 1, 1, 1, 1, 8, 8},
        { 0, 0, 4, 4, 4, 1, 1, 1, 8, 8, 8},
        { 0, 4, 4, 4, 1, 1, 1, 1, 8, 8, 8},
        { 4, 4, 4, 1, 1, 1, 1, 1, 8, 8, 8},
        { 4, 4, 4, 1, 1, 1, 1, 8, 8, 8, 0},
        { 4, 4, 4, 1, 1, 1, 8, 8, 8, 0, 0},
        { 4, 4, 1, 1, 1, 1, 8, 8, 0, 0, 0},
        { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
    };

    private static readonly int width = 11;
    private static readonly int height = 9;
    private static readonly float yOffset = -0.735f;
    private readonly static float xOffset = 1f;
    private static float col = -xOffset - xOffset / 2;
    #endregion
    /*----*/
    #region Properties
    public GameObject block;
    #endregion
    /*----*/
    #region Events
    public byte getBlockValid(byte Pos_x, byte Pos_y)
    {
        return Invalid[Pos_x, Pos_y];
    }
    #endregion

    #endregion

    /*-------------------------------------*/

    #region Draw Manager

    #region Variables 
    GameObject _drawer;
    #endregion
    /*----*/
    #region Properties
    public GameObject Drawer;
    #endregion
    /*----*/
    #region Events

    #endregion

    #endregion

    /*--------------------------------------*/

    #region Card Manager

    #region Variables 
    static GameObject _sCard;
    static float _sWid;
    GameObject _card;
    float wid;
    #endregion

    /*----*/

    #region Properties
    public GameObject Card;
    public static int CardNumber;
    #endregion

    /*----*/

    #region Events
    public bool DrawCard(int stt)
    {
        _card = Instantiate(_sCard, new Vector2(-8f + (_sWid * stt), -4f), Quaternion.identity);
        _card.name = "card_" + stt.ToString();
        _card.transform.SetParent(this.transform);
        return true;
    }
    #endregion


    #endregion

    // Use this for initialization
    void Start()
    {
        #region Block
        if (block != null)
        {
            for (int jj = 0; jj < height; jj++)
            {
                if ((jj % 2 == 0) && (jj != 0))
                    col += xOffset;
                for (int ii = 0; ii < width; ii++)
                {
                    if (Invalid[jj, ii] != 0)

                    {
                        GameObject hex_go;

                        hex_go = (GameObject)Instantiate(
                            block,
                            new Vector2(
                                ii * xOffset - 5.5f + col + (jj % 2) * xOffset / 2f,
                                jj * yOffset + 3f + 0.6f),
                            Quaternion.identity);
                        hex_go.name = "Base_" + ii + "_" + jj;
                        hex_go.transform.SetParent(this.transform);
                        // add start nnvu set Status as create Block
                        BlockOj hexScript = (BlockOj)hex_go.GetComponent(typeof(BlockOj));
                        hexScript.SetStatus(Invalid[jj, ii]);
                    }
                }
            }
        }
        #endregion

        #region Draw
        _drawer = Instantiate(Drawer);
        _drawer.transform.SetParent(this.transform);
        _drawer.name = "Drawer";
        #endregion

        #region Card
        _sCard = Card;
        wid = Card.GetComponent<SpriteRenderer>().bounds.size.x + 0.05f;
        _sWid = wid;
        for (int i = 0; i < 5; i++)
        {
            _card = Instantiate(Card, new Vector2(-8f + (wid * i), -4f), Quaternion.identity);
            _card.name = "card_" + i.ToString();
            _card.transform.SetParent(this.transform.Find("Drawer"));
        }
        CardNumber = 5;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
