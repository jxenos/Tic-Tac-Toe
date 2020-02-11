using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour
{
    public Text[] buttonList_raw;
    public Text[,] buttonList;
    string playerSide;

    void Awake() {
        playerSide = "X";
        SetGameControllerReferenceOnButtons();
    }

    void SetGameControllerReferenceOnButtons() {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList_raw[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);

            for (int x = 0; x < buttonList.Length; x++)
            {
                for (int y = 0; y < buttonList.Length; y++)
                {
                    buttonList[x][y] = buttonList_raw[i];
                }
            }
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
        private Text[] win_line[];

        for (int x = 0; x < buttonList.Length; x++)
        {
            for (int y = 0; y < buttonList.Length; y++)

            {
                win_line[y] = buttonList_raw[x][y];
            }
        }
    }

}
