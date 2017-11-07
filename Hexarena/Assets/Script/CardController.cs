using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    #region Variables
    float wid;
    int j;
    #endregion

    #region Events
    void OnMouseDown()
    {
        wid = gameObject.GetComponent<SpriteRenderer>().bounds.size.x + 0.05f;
        j = Int32.Parse(gameObject.name.Split('_')[1]);
        MainManager.CardNumber -= 1;
        Debug.Log(gameObject.name + " is used - Current card: " + MainManager.CardNumber);
        Destroy(gameObject);
        for (int i = j + 1; i < MainManager.CardNumber + 1; i++)
        {
            GameObject _c = GameObject.Find("card_" + i.ToString());
            //Debug.Log(_c.name);
            if (_c != null)
            {
                _c.transform.position = new Vector2(_c.transform.position.x - wid, _c.transform.position.y);
                _c.name = "card_" + (i - 1).ToString();
            }
        }
    }
    #endregion

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
