using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    #region Variables
    public GameObject Card;
    public static int CardNumber;
    static GameObject _sCard;
    static float _sWid;
    GameObject _card;
    float wid;

    #endregion



    // Use this for initialization
    void Start()
    {
        _sCard = Card;
        wid = Card.GetComponent<SpriteRenderer>().bounds.size.x + 0.05f;
        _sWid = wid;
        for (int i = 0; i < 5; i++)
        {
            _card = Instantiate(Card, new Vector2(-8f + (wid * i), -4f), Quaternion.identity);
            _card.name = "card_" + i.ToString();
            _card.transform.SetParent(this.transform);
        }
        CardNumber = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool DrawCard(int stt)
    {
        _card = Instantiate(_sCard, new Vector2(-8f + (_sWid * stt), -4f), Quaternion.identity);
        _card.name = "card_" + stt.ToString();
        _card.transform.SetParent(this.transform);
        return true;
    }
}
