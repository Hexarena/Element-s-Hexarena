using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawController : MonoBehaviour
{
    #region Variables
    Text DrawText;
    int _cardLeft = 30;
    #endregion

    #region Events
    void OnMouseDown()
    {
        if (_cardLeft > 0 && MainManager.CardNumber < 8)
        {
            _cardLeft -= 1;
            MainManager.CardNumber += 1;
            DrawText.text = "Draw \r\n" + _cardLeft;
            MainManager d = FindObjectOfType<MainManager>();
            d.DrawCard(MainManager.CardNumber - 1);
            Debug.Log("Draw a card - Current card: " + MainManager.CardNumber);
        }
    }
    #endregion

    // Use this for initialization
    void Start()
    {
        DrawText = gameObject.GetComponentInChildren<Text>();
        DrawText.text = "Draw \r\n" + _cardLeft;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
