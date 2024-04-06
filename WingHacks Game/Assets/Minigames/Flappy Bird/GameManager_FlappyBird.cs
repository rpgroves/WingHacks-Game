using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_FlappyBird : MonoBehaviour, MinigameManager
{
    [SerializeField] FlappyBirdObstacles fbo;
    [SerializeField] FlappyBirdPlayer player;
    Vector3 fboStart;
    Vector3 playerStart;
    int score = 0;
    bool won = false;

    private void Start()
    {
        fboStart = fbo.transform.position;
        playerStart = player.transform.position;
    }

    public void GameStart()
    {
        fbo.transform.position = fboStart;
        player.transform.position = playerStart;
    }
    public void GameReset()
    {
        fbo.ToggleSpeed(false);
        player.StartWaiting();
        GameStart();
    }
    public void GameStop()
    {
        
    }

    public int GetScore()
    {
        return score;
    }
    public bool GetWinLose()
    {
        return won;
    }

    public void PlayerStartMovement()
    {
        fbo.ToggleSpeed(true);
    }
}
