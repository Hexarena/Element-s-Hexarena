using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour
{

    public Text DrawText;
    int CardLeft = 30;
    // Use this for initialization
    void Start()
    {
        DrawText.text = "Draw \r\n" + CardLeft;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        if (CardLeft > 0 && CardManager.CardNumber < 8)
        {
            CardLeft -= 1;
            CardManager.CardNumber += 1;
            DrawText.text = "Draw \r\n" + CardLeft;
            CardManager d = FindObjectOfType<CardManager>();
            d.DrawCard(CardManager.CardNumber - 1);
            Debug.Log("Draw a card - Current card: " + CardManager.CardNumber);
        }
    }
}
