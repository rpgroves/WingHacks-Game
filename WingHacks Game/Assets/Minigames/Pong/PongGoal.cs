using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGoal : MonoBehaviour
{
    [SerializeField] GameManager_Pong gm;
    [SerializeField] bool isPlayerGoal = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(isPlayerGoal)
            gm.IncrementOpponent();
        else
            gm.IncrementPlayer();

    }
}
