using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager_Rhythm : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText;
    int playerScore = 0;
    [SerializeField] GameObject pointMap;
    [SerializeField] GameObject pointMapHidden;
    [SerializeField] float dropSpeed = 10.0f;
    [SerializeField] AudioSource music;

    void Start()
    {
        pointMapHidden.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, -dropSpeed * 10.0f * 5.0f));
        music.Play();
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
}
