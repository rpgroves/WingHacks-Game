using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;

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
    private float timer = 0.0f;
    public float timeLimit = 20.0f;
    public float timeToEnd = 8.0f;
    private bool isGameEnding = false;

    void Start()
    {
        pointMapStart = pointMap.transform.position;
    }

    void Update()
    {
        if(gameOngoing)
        {
            timer += Time.deltaTime;
            if(timer > timeLimit)
            {
                GameStop();
            }
        }

        if(isGameEnding)
        {
            music.volume -= Time.deltaTime / timeToEnd;
            if(music.volume < 0.0f)
                music.volume = 0.0f;
        }
        
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
        timer = 0.0f;
    }
    public void GameStop()
    {
        gameOngoing = false;
        pointMapHidden.transform.position = pointMapStart;
        pointMap.transform.position = pointMapStart;
        pointMapHidden.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        
        StartCoroutine(EndRound());
    }
    public IEnumerator EndRound()
    {
        isGameEnding = true;
        yield return new WaitForSeconds (4.0f);
        SceneManager.LoadScene(0);
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
