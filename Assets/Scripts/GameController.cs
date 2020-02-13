using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour
{
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;

    string playerSide;
    int turn;

    void Awake() {
        playerSide = "X";
        turn = 0;
        gameOverPanel.SetActive(false);
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
        //  check for win
        //[0,1,2]
        //[3,4,5]
        //[6,7,8]
        // gross brute force checking for win
        if ((buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) ||
            (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) ||
            (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) ||
            (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) ||
            (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) ||
            (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) ||
            (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) ||
            (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide))
        {
            GameOver();
        }

        if (++turn > 8)
        {
            DrawGame();
        }

        ChangePlayerSide();

    }

    public void ChangePlayerSide()
    {
        playerSide = GetPlayerSide() == "X" ? "O" : "X";
    }

    public void GameOver()
    {
        //win game
        gameOverPanel.SetActive(true);
        gameOverText.text = playerSide + " Wins!";
    }

    public void DrawGame()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "Draw Game";
    }
}
