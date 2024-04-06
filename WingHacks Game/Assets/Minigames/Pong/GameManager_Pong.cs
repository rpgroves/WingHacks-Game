using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager_Pong : MonoBehaviour, MinigameManager
{
    
    int playerScore;
    [SerializeField] TextMeshProUGUI playerScoreText;
    int opponentScore;
    [SerializeField] TextMeshProUGUI opponentScoreText;
    [SerializeField] TextMeshProUGUI centerText;
    [SerializeField] int scoreToWin;
    [SerializeField] GameObject puck;
    [SerializeField] float puckSpeed;
    bool gameWon = false;

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    Vector3 player1Start;
    Vector3 player2Start;

    private void Start()
    {
        player1Start = player1.transform.position;
        player2Start = player2.transform.position;
        GameStart();
    }

    public void IncrementPlayer()
    {
        playerScore++;
        playerScoreText.text = "Player 1: " + playerScore;
        if(playerScore >= scoreToWin)
        {
            gameWon = true;
            GameStop();
        }
        else
            GameReset();
    }
    public void IncrementOpponent()
    {
        opponentScore++;
        opponentScoreText.text = "Player 2: " + opponentScore;
        if(opponentScore >= scoreToWin)
        {
            gameWon = false;
            GameStop();
        }
        else
            GameReset();
    }

    //Start a game
    public void GameStart()
    {
        player1.transform.position = player1Start;
        player2.transform.position = player2Start;
        centerText.gameObject.SetActive(true);
        puck.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f,0.0f,0.0f);
        centerText.text = "Get Ready: 3";
        puck.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        StartCoroutine(HandleStart());
    }
    public IEnumerator HandleStart()
    {
        yield return new WaitForSeconds (1f);
        centerText.text = "Get Ready: 2";
        yield return new WaitForSeconds (1f);
        centerText.text = "Get Ready: 1";
        yield return new WaitForSeconds (1f);
        centerText.text = "Go!";
        
        puck.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1.0f, 0.0f, 0.0f) * 50.0f * puckSpeed);

        yield return new WaitForSeconds (1f);
        centerText.gameObject.SetActive(false);
    }
    //Reset a game
    public void GameReset()
    {
        GameStart();
    }
    //End the game loop
    public void GameStop()
    {
        centerText.gameObject.SetActive(true);
        centerText.text = "Player 1 Wins!";
    }

    public int GetScore()
    {
        if(playerScore - opponentScore > 0)
            return playerScore - opponentScore;
        else
            return 0;
    }
    public bool GetWinLose()
    {
        if(playerScore >= 3)
            return true;
        else
            return false;
    }
}
