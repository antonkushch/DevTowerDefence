using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour {

    private bool gameOver;
    public bool GameOver { get { return gameOver; } set { gameOver = value; } }
    public GameObject gameOverOverlay;

    private bool gameWon;
    public bool GameWon { get { return gameWon; } set { gameWon = value; } }
    public GameObject gameWonOverlay;

    void Start()
    {
        gameOver = false;
        gameWon = false;
    }

	// Update is called once per frame
	void Update ()
    {
        if (gameOver)
            return;

	    if(PlayerStuff.GetHealth() <= 0)
        {
            EndGame();
        }
        if (PlayerStuff.GetGameWon())
        {
            GameWonScreen();
        }
	}

    private void EndGame()
    {
        gameOver = true;
        gameOverOverlay.SetActive(true);
    }

    private void GameWonScreen()
    {
        gameWon = true;
        gameWonOverlay.SetActive(true);
    }
}
