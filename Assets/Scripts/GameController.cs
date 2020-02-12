using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour
{
    public Text[] buttonList;
    string playerSide;

    void Awake() {
        playerSide = "X";
        SetGameControllerReferenceOnButtons();
    }

    void SetGameControllerReferenceOnButtons() {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide() {
        return playerSide;
    }

    public void EndTurn () {
        playerSide = GetPlayerSide() == "X" ? "O" : "X";
        //  check for win
        //[0,1,2]
        //[3,4,5]
        //[6,7,8]
        Debug.Log(buttonList[0].text);
        if ((buttonList[0].text == buttonList[1].text == buttonList[2].text) ||
            (buttonList[3].text == buttonList[4].text == buttonList[5].text) ||
            (buttonList[6].text == buttonList[7].text == buttonList[8].text) ||
            (buttonList[0].text == buttonList[3].text == buttonList[6].text) ||
            (buttonList[1].text == buttonList[4].text == buttonList[7].text) ||
            (buttonList[2].text == buttonList[5].text == buttonList[8].text) ||
            (buttonList[0].text == buttonList[4].text == buttonList[8].text) ||
            (buttonList[2].text == buttonList[4].text == buttonList[6].text))
        {
            //win game
            Debug.Log("win game");
        }
        
    }

}
