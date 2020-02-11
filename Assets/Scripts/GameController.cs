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
        for(int i = 0; i < buttonList.Length; i++){
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
            Debug.Log(buttonList[i]);
        }
    }

    public string GetPlayerSide() {
        return playerSide;
    }

    public void EndTurn () {
        playerSide = GetPlayerSide() == "X" ? "O" : "X";
    }

}
