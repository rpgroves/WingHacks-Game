using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager_Rhythm : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText;
    int playerScore = 0;
    [SerializeField] GameObject pointMap;
    Vector3 pointMapStart;
    [SerializeField] GameObject pointMapHidden;
    [SerializeField] float dropSpeed = 10.0f;
    [SerializeField] AudioSource music;
    [SerializeField] int winScore = 1000;

    public bool gameOngoing = false;

    void Start()
    {
        pointMapStart = pointMap.transform.position;
    }

    void Update()
    {
        pointMap.transform.position = pointMapHidden.transform.position;
    }
    public void IncrementScore(int score)
    {
        playerScore += score;
        playerScoreText.text = "Score: " + playerScore;
    }

    public void GameStart()
    {
        music.Play();
        gameOngoing = true;
        pointMapHidden.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, -dropSpeed * 10.0f * 5.0f));
    }
    public void GameReset()
    {
        gameOngoing = false;
        pointMapHidden.transform.position = pointMapStart;
        pointMap.transform.position = pointMapStart;
        pointMapHidden.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        music.Stop();
    }
    public void GameStop()
    {
    }

    public int GetScore()
    {
        return playerScore;
    }
    public bool GetWinLose()
    {
        if(playerScore > winScore)
            return true;
        else
            return false;
    }

}
